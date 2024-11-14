$(document).ready(function () {

    $('#isDiscounted').on('change', function () {
        $('#discount').prop('disabled', !this.checked); // Enable input if checkbox is checked
    });

    let rowCount = 1;
    $(".addRow").on("click", function (event) {
        event.preventDefault();
        rowCount++;

        let html = `
                <tr>
                    <td>${rowCount}</td>
                    <td style="display:flex; flex-direction:row; justify-content:space-evenly; align-items:center;">
                        <button class="btn btn-pink " style="margin-right:3rem;">ITEM</button>
                        <button class="btn btn-pink ">
                            <span>SERVICES</span>
                        </button>
                    </td>
                    <td>     
                        <button class="btn btn-outline-pink" style="border:none; font-weight:bold;" data-bs-toggle="modal" data-bs-target="#descriptionModal" >VIEW</button>
                    </td>
                    <td>
                        <input list="numberList" class="w-100 text-center form-control" type="number" />
                        <datalist id="numberList">
                            <option value="1"/>
                            <option value="2"/>
                            <option value="3"/>
                            <option value="4"/>
                            <option value="5"/>
                        </datalist>
                    </td>
                    <td>₱<span>0</span></td>
                    <td>₱<span>0</span></td>
                    <td>
                        <input class="w-100 text-center form-control" type="number" />

                    </td>
                    <td>
                        <i class="fas fa-trash "></i>
                    </td>
                </tr>
        `;

        $(".createInvoiceTBody").append(html);

        scrollChatContainer();

    });

    $(".createInvoiceTBody").on("click", ".fa-trash", function () {
        // Find the closest <tr> and remove it
        $(this).closest("tr").remove();
    });

    function scrollChatContainer() {
        var chatContainer = $('.scrollableTable');
        if (chatContainer.is(':visible')) {
            chatContainer.scrollTop(chatContainer[0].scrollHeight);
        }
    }


                 //ADD ITEMS
    $(".addItem").on("click", function (event) {

        event.preventDefault();

    });

    $("#addItemName, #addItemPrice").on("input", function (event) {

        var itemName = $("#addItemName").val();
        var pri = $("#addItemPrice").val();
        var price = parseFloat(pri);

        if (itemName.length > 0 && !isNaN(price)) {
            $("#addItemSubmitBtn").prop("disabled", false);
        }
        else {
            $("#addItemSubmitBtn").prop("disabled", true);

        }
    });


    $("#addItemSubmitBtn").on("click", function (event) {

        var itemName1 = $("#addItemName").val();

        var pri = $("#addItemPrice").val();
        var price1 = parseFloat(pri);

        var description1 = $("#addItemDescription").val();

        $.ajax({
            type: 'POST',
            url: "/Billing/AddItem",
            data: { itemName: itemName1, description: description1, price: price1 },
            dataType: "json",
            success: function (result) {
                toastr.success(result);
            },
            error: function (req, status, error) {
                console.log(status);
            }
        });

        $("#addItemName").val("");
        $("#addItemPrice").val("");
        $("#addItemDescription").val("");

    });




                 //ADD SERVICES

    $("#addServiceName, #addServicePrice").on("input", function (event) {

        var serviceName = $("#addServiceName").val();
        var pri = $("#addServicePrice").val();
        var price = parseFloat(pri);

        if (serviceName.length > 0 && !isNaN(price)) {
            $("#addServicesSubmitBtn").prop("disabled", false);
        }
        else {
            $("#addServicesSubmitBtn").prop("disabled", true);

        }
    });


    $("#addServicesSubmitBtn").on("click", function (event) {

        var serviceName1 = $("#addServiceName").val();

        var pri = $("#addServicePrice").val();
        var price1 = parseFloat(pri);

        var description1 = $("#addServiceDescription").val();

        $.ajax({
            type: 'POST',
            url: "/Billing/AddService",
            data: { serviceName: serviceName1, description: description1, price: price1 },
            dataType: "json",
            success: function (result) {

            },
            error: function (req, status, error) {
                console.log(status);
            }
        });

        $("#addServiceName").val("");
        $("#addServicePrice").val("");
        $("#addServiceDescription").val("");

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