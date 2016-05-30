(function () {
    $(document).ready(function () {
        $("#add-item").click(function (event) {
            $.get("/Borrow/BorrowList", {})
            .done(function (data, textStatus, jqXHR) {
                $("#borrow-list").html(data);
            });
        });
    });
})();