//$(document).ready(function () {

//    $('#isDiscounted').on('change', function () {
//        $('#discountInput').prop('disabled', !this.checked); // Enable input if checkbox is checked
//    });

//    // Initial row count
//    let rowCount = 0;

//    let ItemCount = 0;
//    let ServiceCount = 0;


//    // ADD ROW
//    $(".addRow").on("click", function (event) {
//        event.preventDefault();
//        rowCount++; // Increment row count

//        let html = `
//        <tr>
//            <td class="row-number">${rowCount}</td>
            
//            <td style="display:flex; flex-direction:row; justify-content:space-evenly; align-items:center;" class="button-container">
//                <button class="btn btn-outline-pink itemorservice" style="margin-right:3rem;" onclick="event.preventDefault();">ITEM</button>
//                <button class="btn btn-outline-pink itemorservice" onclick="event.preventDefault();">
//                    <span>SERVICES</span>
//                </button>
//            </td>

//            <td>
//                <button class="btn btn-outline-dark viewButton" data-bs-toggle="modal" data-bs-target="#descriptionModal" onclick="event.preventDefault();">VIEW</button>
//            </td>

//            <td>
//                <input list="numberList" id="quantity" class="w-100 text-center form-control" type="number" />
//                <datalist id="numberList">
//                    <option value="1"/>
//                    <option value="2"/>
//                    <option value="3"/>
//                    <option value="4"/>
//                    <option value="5"/>
//                </datalist>
//            </td>
//            <td>₱<span id="price">0</span><input type="hidden" id="pricehidden"/></td>
//            <td>₱<span id="amount">0</span><input type="hidden" id="amounthidden"/><input type="hidden" id="amountSubTotal"/></td>
//            <td>
//                <input id="philCovered" class="w-100 text-center form-control" type="number"/>
//            </td>
//            <td style="">
//                <i class="fas fa-trash "></i>
//            </td>
//        </tr>
//    `;

//        $(".createInvoiceTBody").append(html);

//        scrollChatContainer();
//        toastr.success("Row Successfully Added!");
//    });

//    // DELETE ROW
//    $(".createInvoiceTBody").on("click", ".fa-trash", function () {
//        $(this).closest("tr").remove();
//        rowCount--; // Decrement row count
//        updateRowNumbers(); // Update row numbers after deletion
//        calculateTotal();
//    });

//    // Function to update row numbers
//    function updateRowNumbers() {
//        $(".createInvoiceTBody tr").each(function (index) {
//            $(this).find(".row-number").text(index + 1); // Update the row number
//        });
//    }




//                     //ITEM OR SERVICES BUTTON
//    $(".createInvoiceTBody").on('click', '.itemorservice', function () {
//        var select;

//        var row = $(this).closest('tr'); // Move this line outside the condition

//        if ($(this).text().trim() === 'ITEM') {

    

//            select = $(`<select class="form-control selectItems" style="width: 100%; text-align:center;" name="Items[${ItemCount}].ItemName">
//                </select>`);

//            //ALL ITEMS
//            $.ajax({
//                type: 'POST',
//                url: "/Billing/AllItems",
//                dataType: "json",
//                success: function (result) {

//                    if (result.length > 0) {

//                        var option1 = `
//                                 <option >SELECT ITEMS</option>
//                            `;
//                        select.append(option1);

//                        result.forEach(function (allItems) {
//                            var option = `
//                                 <option class="optionTag" value="${allItems.itemName}" data-price="${allItems.price}" data-name="${allItems.itemName}" data-desc="${allItems.description}">${allItems.itemName}</option>
//                            `;

//                            select.append(option);



//                        });
//                    }
//                },
//                error: function (req, status, error) {
//                    console.log(status);
//                }
//            });

//            // Set the name attributes for item inputs
//            setItemOrServiceNames(row, 'Items', ItemCount);

//            ItemCount++;


//        } else if ($(this).text().trim() === 'SERVICES') {



//            select = $(`<select class="form-control selectServices" style="width: 100%; text-align:center;" name="Services[${ServiceCount}].ServiceName">
//                </select>`);

//            //ALL SERVICES
//            $.ajax({
//                type: 'POST',
//                url: "/Billing/AllServices",
//                dataType: "json",
//                success: function (result) {
//                    console.log(result);

//                    if (result.length > 0) {

//                        var option1 = `
//                                 <option >SELECT SERVICES</option>
//                            `;
//                        select.append(option1);

//                        result.forEach(function (allServices) {
//                            var option = `
//                                 <option class="optionTag" value="${allServices.serviceName}" data-price="${allServices.price}" data-name="${allServices.serviceName}" data-desc="${allServices.description}">${allServices.serviceName}</option>
//                            `;

//                            select.append(option);
//                        });
//                    }


//                },
//                error: function (req, status, error) {
//                    console.log(status);
//                }
//            });

//            // Set the name attributes for service inputs
//            setItemOrServiceNames(row, 'Services', ServiceCount);

//            ServiceCount++;

//        }

//        // Replace the button container in the current row only
//        $(this).closest('tr').find('.button-container').html(select);
//    });


//    function setItemOrServiceNames(row, type, count) {
//        row.find("#quantity").attr('name', `${type}[${count}].Quantity`);
//        row.find("#pricehidden").attr('name', `${type}[${count}].Price`);
//        row.find("#amounthidden").attr('name', `${type}[${count}].Amount`);
//        row.find("#philCovered").attr('name', `${type}[${count}].PhilHealthCovered`);
//    }


//            //VIEW BUTTON
//    $(".createInvoiceTBody").on("click", ".viewButton", function () {
//        var row = $(this).closest('tr');
//        var selectedItem = row.find('.selectItems option:selected');
//        var selectedService = row.find('.selectServices option:selected');

//        // Get the name and description from the selected option
//        var name = selectedItem.length > 0 ? selectedItem.data("name") : selectedService.data("name");
//        var description = selectedItem.length > 0 ? selectedItem.data("desc") : selectedService.data("desc");

//        // Display in modal
//        $("#descName").text(name || "No Name Selected");
//        $("#desc").text(description || "No Description Available");
//    });



//    // Change event for item selection
//    $(document).on("change", ".selectItems", function () {
//        var price = $(this).find("option:selected").data("price");
//        var row = $(this).closest('tr');
//        updateRowPrice(row, price);
//    });



//    // Change event for service selection
//    $(document).on("change", ".selectServices", function () {
//        var price = $(this).find("option:selected").data("price");
//        var row = $(this).closest('tr');
//        updateRowPrice(row, price);
//    });


//    function updateRowPrice(row, price) {
//        row.find('#price').text(price.toFixed(2));
//        row.find('#pricehidden').val(price.toFixed(2));
//        calculateAmount(row);
//    }


//    // Calculate amount when quantity changes
//    $(".createInvoiceTBody").on("input", "#quantity", function () {
//        var row = $(this).closest('tr');
//        calculateAmount(row);
//    });

//    // Calculate amount when PHILHEALTH COVERED changes
//    $(".createInvoiceTBody").on("input", "#philCovered", function () {
//        var row = $(this).closest('tr');
//        calculateAmount(row);
//    });


//    function calculateAmount(row) {
//        var quantity = parseFloat(row.find("#quantity").val()) || 0;
//        var price = parseFloat(row.find("#price").text()) || 0;
//        var philCovered = parseFloat(row.find("#philCovered").val()) || 0;

//        var amount = (quantity * price) - philCovered;
//        amount = Math.max(amount, 0); // Ensure amount is not negative

//        row.find("#amount").text(amount.toFixed(2));
//        row.find("#amounthidden").val(amount.toFixed(2));
//        row.find("#amountSubTotal").val(amount.toFixed(2));

//        calculateTotal(); // Recalculate total after amount update
//    }

//    $("#discountInput").on("input", function () {
//        calculateTotal();
//    });

//    function calculateTotal() {
//        let total = 0;
//        let philHealthCoveredTotal = 0;

//        $(".createInvoiceTBody tr").each(function () {
//            var amount = parseFloat($(this).find("#amount").text().replace('₱', '')) || 0;
//            total += amount;

//            var philCovered = parseFloat($(this).find("#philCovered").val()) || 0;
//            philHealthCoveredTotal += philCovered;
//        });

//        let discountPercentage = parseFloat($("#discountInput").val()) || 0;

//        let discount = total * (discountPercentage / 100);

//        let finalTotal = total - discount;


//        $("#totalAmountShow").text("Total Amount: ₱" + finalTotal.toFixed(2));
//        $("#philHealthTotalShow").text("₱" + philHealthCoveredTotal.toFixed(2));
//        $("#subTotalShow").text("₱" + (total + philHealthCoveredTotal).toFixed(2));

//        $("#totalAmountHidden").val(finalTotal.toFixed(2));
//        $("#philHealthTotalHidden").val(philHealthCoveredTotal.toFixed(2));
//        $("#subTotalHidden").val((total + philHealthCoveredTotal).toFixed(2));
//    }














//                //AUTO BOTTOM SCROLLBAR
//    function scrollChatContainer() {
//        var chatContainer = $('.scrollableTable');
//        if (chatContainer.is(':visible')) {
//            chatContainer.scrollTop(chatContainer[0].scrollHeight);
//        }
//    }


//                 //ADD ITEMS
//    $(".addItem").on("click", function (event) {

//        event.preventDefault();

//    });

//    $("#addItemName, #addItemPrice").on("input", function (event) {

//        var itemName = $("#addItemName").val();
//        var pri = $("#addItemPrice").val();
//        var price = parseFloat(pri);

//        if (itemName.length > 0 && !isNaN(price)) {
//            $("#addItemSubmitBtn").prop("disabled", false);
//        }
//        else {
//            $("#addItemSubmitBtn").prop("disabled", true);

//        }
//    });


//    $("#addItemSubmitBtn").on("click", function (event) {

//        var itemName1 = $("#addItemName").val();

//        var pri = $("#addItemPrice").val();
//        var price1 = parseFloat(pri);

//        var description1 = $("#addItemDescription").val();

//        $.ajax({
//            type: 'POST',
//            url: "/Billing/AddItem",
//            data: { itemName: itemName1, description: description1, price: price1 },
//            dataType: "json",
//            success: function (result) {
//                toastr.success(result);
//            },
//            error: function (req, status, error) {
//                console.log(status);
//            }
//        });

//        $("#addItemName").val("");
//        $("#addItemPrice").val("");
//        $("#addItemDescription").val("");

//    });




//                 //ADD SERVICES

//    $("#addServiceName, #addServicePrice").on("input", function (event) {

//        var serviceName = $("#addServiceName").val();
//        var pri = $("#addServicePrice").val();
//        var price = parseFloat(pri);

//        if (serviceName.length > 0 && !isNaN(price)) {
//            $("#addServicesSubmitBtn").prop("disabled", false);
//        }
//        else {
//            $("#addServicesSubmitBtn").prop("disabled", true);

//        }
//    });


//    $("#addServicesSubmitBtn").on("click", function (event) {

//        var serviceName1 = $("#addServiceName").val();

//        var pri = $("#addServicePrice").val();
//        var price1 = parseFloat(pri);

//        var description1 = $("#addServiceDescription").val();

//        $.ajax({
//            type: 'POST',
//            url: "/Billing/AddService",
//            data: { serviceName: serviceName1, description: description1, price: price1 },
//            dataType: "json",
//            success: function (result) {
//                toastr.success(result);

//            },
//            error: function (req, status, error) {
//                console.log(status);
//            }
//        });

//        $("#addServiceName").val("");
//        $("#addServicePrice").val("");
//        $("#addServiceDescription").val("");

//    });






//                     //PATIENT NAME SEARCH
//    var searchResultContainer = $(".searchResultsDiv");
//    $("#patientNameInput").on("input", function (event) {


//        var name = $("#patientNameInput").val();

//        if (name.length > 0) {
//            searchResultContainer.show();
//            searchResultContainer.empty();
//            $.ajax({
//                type: 'POST',
//                url: "/Billing/PatientSearchResult",
//                data: { patientName: name},
//                dataType: "json",
//                success: function (result) {

                    

//                    if (result.length > 0) {
                
//                        result.forEach(function (patient) {

//                            console.log(patient);

//                            var html = `
//                                  <li class="selectedPatient" data-id="${patient.patientID}" data-name="${patient.firstName} ${patient.middleName ? patient.middleName + ' ' : ''}${patient.lastName}">${patient.firstName} ${patient.middleName ? patient.middleName + ' ' : ''}${patient.lastName}</li>
//                            `;
         
//                            searchResultContainer.append(html);

//                            $(".selectedPatient").on("click", function (event) {

//                                var name = $(this).data("name");

//                                var id = $(this).data("id");

//                                $("#patientNameInput").val(name);
//                                $("#patientIdHidden").val(id);
                                
//                                searchResultContainer.hide();


//                            });


//                        });



//                    } else {
       
//                        searchResultContainer.append('<li>No Results Found</li>');
//                    }

//                },
//                error: function (req, status, error) {
//                    console.log(status);
//                }
//            });




//        }
//        else {
//            searchResultContainer.hide();
//        }

//    });

//    $(document).on("click", function (event) {
//        if (!$(event.target).closest("#patientNameInput").length && !$(event.target).closest(".searchResultsDiv").length) {
//            searchResultContainer.hide();
//        }
//    });



//});