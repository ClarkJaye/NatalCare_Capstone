$(document).ready(function () {

    $(".addRow").on("click", function (event) {
        event.preventDefault();



        let html = `
            <tr>
                <td>2</td>
                <td>
                    <select class="w-100 text-center form-select">
                        <option>PRENATAL/POSTNATAL CARE</option>
                        <option>2</option>
                    </select>
                </td>
                <td>text</td>
                <td>2</td>
                <td>200</td>
                <td>400</td>
                <td>Delete</td>
            </tr>
        `;

        $(".createInvoiceTBody").append(html);
    });

    //$.ajax({
    //    type: 'GET',
    //    url: "/Admin/AddDataSheetUserExist",
    //    data: { name: resourceName },
    //    dataType: "json",
    //    success: function (result) {
    //        if (result == "No") {

    //            alert("This User Doesn't have a Section! Please put a Section of this User First!");
    //            $("#addDataSheetSection").val("");
    //            $("#addDataSheetSectionDisplay").val("");
    //        }
    //        else {

    //            $("#addNewDataButton").prop("disabled", false);

    //            $("#addDataSheetSection").val(result);
    //            $("#addDataSheetSectionDisplay").val(result);

    //        }
    //    },
    //    error: function (req, status, error) {
    //        console.log(status);
    //    }
    //});

});