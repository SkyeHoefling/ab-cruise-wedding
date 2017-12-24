galleryControl = {
    uri: '',
    initialize: function(updateUri){
        $('#gallery-table').DataTable({
            "searching": false,
            "ordering": false,
            "info": true,
            "lengthChange": false
        });        

        galleryControl.uri = updateUri;
        galleryControl.update('Engagement');
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