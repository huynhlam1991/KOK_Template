
$(function () {
    $(".datepicker").datepicker({
        showOn: "both",
        dateFormat: 'dd/mm/yy',
        buttonImage: "/Areas/admin/Content/assets/images/icon4.png",
        buttonImageOnly: true,
        buttonText: "Select date"
    });
});

$(window).load(function () {
    n = $(document).height();
    $(".aside-left").height(n - 46);
})

$(document).ready(function () {
    $('#table-kh').dataTable({
        "columnDefs": [{
            "targets": 'no-sort',
            "orderable": false,
        }],
        aaSorting: [[1, 'asc']]
    });
})
