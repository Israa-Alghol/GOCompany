function FilterVehicle() {

    $("#tblDriver tbody tr").remove();
    $.ajax({
        type: 'GET',
        url: 'https://localhost:44333/Vehicle/GetVehicles',
        success: function (data) {
            /*var t = document.getElementById("navbar");*/
            console.log(data);
            var Items = '';
            $.each(data, function (i, Item) {
                var rows = "<tr>"
                    + "<td>" + Item.ID + "</td>"
                    + "<td>" + Item.Name + "</td>"
                    + "</tr>";
                $('#tblDriver tbody').append(rows);
            });
        },

    });
    return false;
}


(() => {
    FilterVehicle();
})();

