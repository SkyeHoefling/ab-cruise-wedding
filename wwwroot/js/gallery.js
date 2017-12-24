galleryControl = {
    uri: '',
    initialize: function(updateUri, container){
        $('#gallery-table').DataTable({
            "searching": false,
            "ordering": false,
            "info": true,
            "lengthChange": false
        });        

        galleryControl.uri = updateUri;
        galleryControl.update(container);
    },
    update: function(container){
        $('#gallery-wrapper').load(galleryControl.uri + '?container=' + container, function(){
            $('#orbit-gallery').foundation();
            $('#gallery-thumbnail-carousel').slick({
                slidesToShow: 4
            });
        });
    }
};