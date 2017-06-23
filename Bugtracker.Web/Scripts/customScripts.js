$('#personTable tr').click(function () {
    var res = $(this).find('input').val();

    $('#ticketTable tbody tr').each(function () {
        var person = $(this).find('input').val();
        if (person != res) {
            $(this).hide(250);
        } else {
            $(this).show(250);
        }

       
    }); 
});

