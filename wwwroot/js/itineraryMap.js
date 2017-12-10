itineraryMap = {
    $campBrockway: null,
    $delLago: null,
    $map: null,
    $view: null,
    $zoom: null,
    initialize: function(){
        itineraryMap.$campBrockway = ol.proj.fromLonLat([-75.993466, 42.927426]);
        itineraryMap.$delLago = ol.proj.fromLonLat([-76.847175, 42.967603]);
        itineraryMap.$zoom = 15;

        itineraryMap.$view = new ol.View({
            center: itineraryMap.$campBrockway,
            zoom: itineraryMap.$zoom
        });
        var vectorLayer = itineraryMap.getMarkers();

        itineraryMap.$map = new ol.Map({
            target: 'map',
            layers: [
                new ol.layer.Tile({
                    preload: 4,
                    source: new ol.source.OSM()
                }),
                vectorLayer
            ],
            loadTilesWhileAnimating: true,
            view: itineraryMap.$view
        });

        var height = $('.itinerary .columns:first').height() * 1.5;
        $('#map').height(height);
        itineraryMap.$map.updateSize();
    },
    getMarkers: function(){
        var markers = [
            new ol.Feature({
                type: 'icon',
                geometry: new ol.geom.Point(itineraryMap.$campBrockway)
            }),
            new ol.Feature({
                type: 'icon',
                geometry: new ol.geom.Point(itineraryMap.$delLago)
            })
        ];

        var vectorLayer = new ol.layer.Vector({
            source: new ol.source.Vector({
                features: markers
            })
        });

        return vectorLayer;
    },
    panMap: function(location, zoom){
        var currentZoom = null;
        var duration= 15000;

        if(zoom != undefined){
            currentZoom = zoom;
        } else {
            currentZoom = itineraryMap.$zoom;
        }

        itineraryMap.$view.animate({
            center: location,
            duration:duration,
            zoom: currentZoom
        });
    }
};