galleryControl = {
    initialize: function(){
        $('#gallery').DataTable({
            "searching": false,
            "ordering": false,
            "info": true,
            "lengthChange": false
        });
    }
};