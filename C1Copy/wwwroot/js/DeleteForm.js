function DeleteForm (addressID, route){
    var id = id;
    var route = route
    var Address = document.getElementById('address').value;
    $.ajax({
        url: route,
        type: 'delete',
        data: {addressID: addressID},
        success: function(){
            var Address = document.getElementById('address').value;
            var tableRef = document.getElementById("addresstable").getElementsByTagName('tbody')[0];
            
            Toasty();
        }
    });
}