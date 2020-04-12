(function ($) {
  "use strict";

  var responsiveHelper = undefined;
  var breakpointDefinition = {
    tablet: 1024,
    phone: 480,
  };

  // Initialize datatable showing a search box at the top right corner
  var initEmployeesTable = function () {
    var table = $("#employeesTable");

    var settings = {
      sDom: "<t><'row'<p i>>",
      sPaginationType: "bootstrap",
      destroy: true,
      scrollCollapse: true,
      oLanguage: {
        sLengthMenu: "_MENU_ ",
        sInfo: "Showing <b>_START_ of _END_</b> of _TOTAL_ entries",
      },
      iDisplayLength: 10,
      ajax: {
        url: "/Employee/ShowAllEmployees",
        type: "GET",
        contentType: "application/json",
        dataSrc: "",
      },
      columnDefs: [
        {
          targets: 8,
          data: "id",
          defaultContent:
            "<button class='btn btn-primary btn-cons';'>Edit</button>",
        },
        {
          targets: 7,
          render: function (data) {
            return moment(data).format("YYYY-MM-DD");
          },
        },
      ],
      columns: [
        { data: "id" },
        { data: "firstName" },
        { data: "lastName" },
        { data: "dni" },
        { data: "gender" },
        { data: "area" },
        { data: "seniority" },
        { data: "hiringDate" },
        { data: null },
      ],
    };
    table.dataTable(settings);
    // search box for table
    $("#search-table").keyup(function () {
      table.fnFilter($(this).val());
    });
  };
  initEmployeesTable();
})(window.jQuery);

$("#employeesTable tbody").on("click", "button", function () {
  var table = $("#employeesTable");
  var data = table.dataTable().api().row($(this).parents("tr")).data();
  var idEmployee = data["id"];
  location.href = "ViewDetails?id=" + idEmployee;
});

//FUNCIONES PARA EL MODAL Y LA VISTA PARCIAL
$(function () {
  $("#manySubmits").on("click", function (evt) {
    evt.preventDefault();
    $.post("Employee/CreateEmployee", $("form").serialize(), function () {
      $("#partialForm").trigger("reset");
    });
  });
});

$(function () {
  $("#submit").on("click", function (evt) {
    evt.preventDefault();
    $.post("Employee/CreateEmployee", $("form").serialize(), function () {
      location.reload();
    });
  });
});
