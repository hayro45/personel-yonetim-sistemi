$(function () {

    $("#tblDepartmanlar").DataTable({
        "language": {
            "url": "//cdn.datatables.net/plug-ins/9dcbecd42ad/i18n/Turkish.json"
        }
    });
    $("#tblDepartmanlar").on("click", ".btnDepartmanSil", function () {
        var btn = $(this);
        bootbox.confirm("Departmanı silmek istediğinizden emin misiniz ?", function (result) {
            if (result) {
                var id = btn.data("id");
                $.ajax({
                    type: "GET",
                    url: "/Departman/Sil/" + id,
                    success: function () {
                        btn.parent().parent().remove();
                    }
                });
            }
        });
    });
    $("#tblPersoneller").DataTable({
        "language": {
            "url": "//cdn.datatables.net/plug-ins/9dcbecd42ad/i18n/Turkish.json"
        }
    });
    $("#tblPersoneller").on("click", ".btnPersonelSil", function () {
        var btn = $(this);
        bootbox.confirm("Personeli silmek istediğinizden emin misiniz ?", function (result) {
            if (result) {
                var id = btn.data("id");
                $.ajax({
                    type: "GET",
                    url: "/Personel/Sil/" + id,
                    success: function () {
                        btn.parent().parent().remove();
                    }
                });
            }
        });
    });
});

function CheckDateTypeIsValid(dateElement) {
    var value = $(dateElement).val();
    if (value == '') {
        $(dateElement).valid("false");
    } else {
        $(dateElement).valid();
    }
}
