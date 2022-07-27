// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function GetList() {
    $.ajax({
        url: "/Student/GetListPartial",
        type: "GET",
        success: function (response) {
            $("#list").html(response);
        }
    })
}
$(document).ready(function () {
    if (window.location == "https://localhost:44375/Student")
        GetList();
});

function GetCreateTable() {
    $.ajax({
        url: "/Student/CreatePartial",
        type: "GET",
        success: function (response) {
            //$("#list").hide(),
            $("#Create").html(response)
        }
    })
}

function AddStudentAJ() {
    let a = {
        name: $("#NameCreate").val(),
        class: $("#ClassCreate").val(),
        schoolID: $("#SchoolIdCreate").val()
    }
    $.ajax({
        url: "/Student/AddStudentAJ",
        type: "POST",
        data: a,
        dataType: "json",
        success: function (response) {
            if (response == "Ok") {
                GetList();
                $("#NameCreate").val("");
                $("#ClassCreate").val("");  
                $("#bildiri").html("kayıt başarılı");
            }
        }
    })
}
function CloseCreateTable() {
    $("#Create").html("");
}
function CloseUpdataTable() {
    $("#Update").html("");
}
function CloseAddLessonTable() {
    $("#AddLesson").html("");
}
function GetUpdateTable(id) {
    $.ajax({
        url: "/Student/UpdatePartial/"+id,
        type: "GET",
        success: function (response) {
            //$("#list").hide(),
            $("#Update").html(response)
        }
    })
}

function UpdateStudentAJ(id) {    

    let a = {
        name: $("#NameUpdate").val(),
        class: $("#ClassUpdate").val(),
        schoolID: $("#SchoolIDUpdate").val()
    }
    $.ajax({
        url: "/Student/UpdateStudentAJ/"+id,
        type: "POST",
        data: a,
        dataType: "json",
        success: function (response) {
            if (response == "Ok") {
                GetList();
                $("#NameUpdate").val("");
                $("#ClassUpdate").val("");
                $("#bildiri").html("Update Başarılıdır");
            }
        }
    })
}

function DeleteStudent(id) {
    let a = { int:id }
    $.ajax({
        url: "/Student/Delete/" + id,
        type: "POST",
        data: a,
        dataType: "json",
        success: function (response) {
            if (response == "Ok") {
                GetList();
                $("#NameUpdate").val("");
                $("#ClassUpdate").val("");
               
            }
        }
    })

}

function GetAddLessonTable(id) {
    $.ajax({
        url: "/Student/AddLessonPartial/" + id,
        type: "GET",
        success: function (response) {
            //$("#list").hide(),
            $("#AddLesson").html(response)
        }
    })
}

function AddLesson(id) {
    let a = {
        lessonID: $("#LessonID").val()
    }
    $.ajax({
        url: "/Student/AddLesson/" + id,
        type: "POST",
        data: a,
        dataType: "json",
        success: function (response) {
            if (response == "Ok") {
                GetList();
                $("#bildiri").html("Ders başarıyla eklendi");

            }
        }
    })
}
