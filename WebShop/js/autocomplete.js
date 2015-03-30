
$(function () {
    $('#<%= searchTXT1.ClientID %>').autocomplete({
        source: function (request, response) {
            $.ajax({
                url: "BookStoreService.asmx/GetKnjigeAutor",
                data: "{ 'upit': '" + request.term + "' }",
                type: "POST",
                dataType: "json",
                contentType: "application/json;charset=utf-8",
                success: function (data) {
                    response(data.d);
                },
                error: function (result) {
                    alert('Postoji problem pri pretraživanju!');
                }
            });
        },
        minLength: 0
    });
});