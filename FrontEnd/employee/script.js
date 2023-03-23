
function listHideFormShow() {
    $("#form-page").show();
    $("#list-page").hide();
}

function listShowFormHide() {
    $("#form-page").hide();
    $("#list-page").show();

}

function switchButtons() {
    var saveBtn = $("#savebtn");
    var updateBtn = $("#updatebtn");

    if (saveBtn.css("display") === "none") {
        saveBtn.show();
        updateBtn.hide();
    } else {
        saveBtn.hide();
        updateBtn.show();
    }
}

function createEmployee() {
    var employee = {};

    if ($('#first-name').val() === '' || $('#last-name').val() === '' || $('#designation').val() === '' || $('#gender').val() === '' || $('#email').val() === '' || $('#phone').val() === '' || $('#about-me').val() === '') {
        alert("Please filled the missing input")
    }
    else {

        employee.FirstName = $('#first-name').val();
        employee.LastName = $('#last-name').val();
        employee.Designation = $('#designation').val();
        employee.Gender = $('#gender').val();
        employee.Email = $('#email').val();
        employee.PhoneNumber = $('#phone').val();
        employee.EmployeeDescription = $('#about-me').val();
        employee.EmployeePicuture = $('#profile-picture').attr('src');

        if (employee) {

            $.ajax({
                url: "https://localhost:5055/api/Employee/AddNewEmployee",
                contentType: "application/json;",
                //dataType: "json",
                data: JSON.stringify(employee),
                type: "POST",
                success: function (result) {
                    listShowFormHide();
                    location.reload();
                },
                error: function (msg) {
                    listShowFormHide();
                    location.reload();
                }
            });
        }
    }
}

function clearForm() {
    $('#first-name').val('');
    $('#last-name').val('');
    $('#designation').val('');
    $('#gender').val('');
    $('#email').val('');
    $('#phone').val('');
    $('#about-me').val('');
    $('#file-upload').val('');
}

function showEmployees() {
    $.ajax({
        url: "https://localhost:5055/api/Employee/GetAllEmployee",
        contentType: "application/json;",
        dataType: "json",
        type: "GET",
        success: function (response) {
            var employeeList = response;
            var employeeContainer = $(".container-fluid");
            for (var i = 0; i < employeeList.length; i++) {
                var employee = employeeList[i];
                var card = $('<div class="card" style="width:300px"></div>');
                var image = $('<img src="' + employee.employeePicuture + '" alt="Image" id="image-card" style="width:100%">');
                var cardBody = $('<div class="card-body"></div>');
                var name = $('<h4 class="card-title">' + employee.firstName + ' ' + employee.lastName + '</h4>');
                var position = $('<p class="card-text">' + employee.designation + '<br>' + employee.employeeDescription + '</p>');
                var profileLink = $('<a href="#" class="btn btn-primary " id ="see-btn" data-employeeid="' + employee.employeeID + '">See Profile</a>');
                var removeButton = $('<button class="btn btn-danger" data-employeeid="' + employee.employeeID + '">Remove</button>');

                removeButton.click(function () {
                    var employeeID = $(this).data('employeeid');
                    deleteEmployee(employeeID);
                });
                profileLink.click(function () {
                    var employeeID = $(this).data('employeeid');
                    EditEmployee(employeeID);
                });
                cardBody.append(name);
                cardBody.append(position);
                cardBody.append(profileLink);
                cardBody.append(removeButton);
                card.append(image);
                card.append(cardBody);
                employeeContainer.append(card);
            }
        },
        error: function (xhr) {
        }
    });
}

function deleteEmployee(id) {
    debugger;
    $.ajax({
        url: "https://localhost:5055/api/Employee/DeleteEmployee/" + id,
        contentType: "application/json;",
        dataType: "json",
        type: "DELETE",
        success: function () {
            listShowFormHide();
            location.reload();
        },
        error: function (xhr) {
                listShowFormHide();
                location.reload();
        }
    });
}

function EditEmployee(id) {
    $.ajax({
        url: "https://localhost:5055/api/Employee/GetEmployeeByID/" + id,
        contentType: "application/json;",
        dataType: "json",
        type: "GET",
        success: function (response) {

            switchButtons();
            listHideFormShow();
            $("#employeeid").val(response.employeeID);
            $('#first-name').val(response.firstName);
            $('#last-name').val(response.lastName);
            $('#designation').val(response.designation);
            $('#gender').val(response.gender);
            $('#email').val(response.email);
            $('#phone').val(response.phoneNumber);
            $('#about-me').val(response.employeeDescription);
            $('#profile-picture').attr('src', response.employeePicuture);

        },
        error: function (xhr) {

        }
    });
}

function UpdateEmployee() {
    var employee = {};

    employee.EmployeeID = $("#employeeid").val();
    employee.FirstName = $('#first-name').val();
    employee.LastName = $('#last-name').val();
    employee.Designation = $('#designation').val();
    employee.Gender = $('#gender').val();
    employee.Email = $('#email').val();
    employee.PhoneNumber = $('#phone').val();
    employee.EmployeeDescription = $('#about-me').val();
    employee.EmployeePicuture = $('#profile-picture').attr('src');

    if (employee) {
        $.ajax({
            url: "https://localhost:5055/api/Employee/UpdateEmployee",
            contentType: "application/json;",
            //dataType: "json",
            data: JSON.stringify(employee),
            type: "POST",
            success: function (response) {
                listShowFormHide();
                location.reload();
            },
            error: function (msg) {
                debugger;
                listShowFormHide();
                location.reload();
            }
        });
    }
}

//Image Section
$('#upload-button').click(function () {
    $('#image-input').click();
});

function previewImage(event) {
    var input = event.target;
    var reader = new FileReader();
    reader.onload = function () {
        var dataURL = reader.result;
        $('#profile-picture').attr('src', dataURL);
    };
    reader.readAsDataURL(input.files[0]);
}

function removeImage() {
    $('#profile-picture').attr('src', 'aa.png');
    $('#image-input').val(null);
}
