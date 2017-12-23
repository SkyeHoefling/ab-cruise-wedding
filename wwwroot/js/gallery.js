galleryControl = {
    initialize: function(){
        $('#gallery-table').DataTable({
            "searching": false,
            "ordering": false,
            "info": true,
            "lengthChange": false
        });
    }
};