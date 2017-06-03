itineraryMap = {
    $newYork: null,
    $florida: null,
    $cococay: null,
    $nassau: null,
    $map: null,
    $view: null,
    initialize: function(){
        itineraryMap.$newYork = ol.proj.fromLonLat([-74.072564, 40.665126]);

        itineraryMap.$view = new ol.View({
            center: itineraryMap.$newYork,
            zoom: 10
        });

        itineraryMap.$map = new ol.Map({
        target: 'map',
        layers: [
          new ol.layer.Tile({
            preload: 4,
            source: new ol.source.OSM()
          })
        ],
        loadTilesWhileAnimating: true,
        view: itineraryMap.$view
      });

      var height = $('.itinerary .columns:first').height();
      $('#map').height(height);
      itineraryMap.$map.updateSize();
    },
    panMap: function(location){
        itineraryMap.$view.animate({
            center: location,
            duration:3000
        });
    }
};