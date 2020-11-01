

//// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(function () {

    function enableBuzzers() {
        
        document.getElementById("buzzer_1").disabled = false;
        document.getElementById("buzzer_2").disabled = false;
        document.getElementById("buzzer_3").disabled = false;
        document.getElementById("buzzer_4").disabled = false;
        document.getElementById("buzzer_5").disabled = false;
        document.getElementById("buzzer_6").disabled = false;
    }
    function disableBuzzers() {

        $.ajax({
            type: "POST",
            dataType: 'json',
            url: "/Exams/GetActiveQustion",
           
            cache: false,
            success: function (result) {
               
                document.getElementById("question_card").textContent = result.description;
               
                if (result.hasOption) {
                    
                    document.getElementById("buzzer_option1").classList.remove("d-none");
                    document.getElementById("buzzer_option2").classList.remove("d-none");
                    document.getElementById("buzzer_option3").classList.remove("d-none");
                    document.getElementById("buzzer_option4").classList.remove("d-none");
                    document.getElementById("buzzer_option1").innerHTML = result.option1;
                    document.getElementById("buzzer_option2").innerHTML = result.option2;
                    document.getElementById("buzzer_option3").innerHTML = result.option3;
                    document.getElementById("buzzer_option4").innerHTML = result.option4;
                }
                else{
                   
                    document.getElementById("buzzer_option1").classList.add("d-none");
                    document.getElementById("buzzer_option2").classList.add("d-none");
                    document.getElementById("buzzer_option3").classList.add("d-none");
                    document.getElementById("buzzer_option4").classList.add("d-none");
                }

            }
        });

        
        document.getElementById("buzzer_1").disabled = true;
        document.getElementById("buzzer_2").disabled = true;
        document.getElementById("buzzer_3").disabled = true;
        document.getElementById("buzzer_4").disabled = true;
        document.getElementById("buzzer_5").disabled = true;
        document.getElementById("buzzer_6").disabled = true;
    }

    function startMcq(id) {
        location.href = '/Home/Mcq?examId=' + id;
       
    }
    function stopMcq(id) {
        location.href = '/Home/StopMcq?examId=' + id;

    }
    function getMcqResult(id) {
        location.href = '/Exams/GetMcqResult?examId=' + id;

    }



    function pressBuzzer() {

        $.ajax({
            type: "POST",
            dataType: 'json',
            url: "/Exams/GetBuzzertimes",
           
            cache: false,
            success: function (result) {
                $.each(result, function (index, value) {
                    
                    if (value.pressTime == null) {
                        document.getElementById("buzzer" + value.buzzerNumber + "_time").textContent = "Not Pressed";
                    }
                    else {


                        var str = value.pressTime;
                        var pressDate = new Date(str);
                        var pressHour = pressDate.getHours();
                        var pressMinute = pressDate.getMinutes();
                        var pressSecond = pressDate.getSeconds();
                        var pressMiliSecond = pressDate.getMilliseconds();

                        var str2 = value.enableTime;
                        var enableDate = new Date(str2);
                        var enableHour = enableDate.getHours();
                        var enableSecond = enableDate.getSeconds();
                        var enableMinute = enableDate.getMinutes();
                        var enableMiliSecond = enableDate.getMilliseconds();

                        var pressTotalSecond = eval((pressHour * 3600) + (pressMinute * 60) + pressSecond);
                        var enableTotalSecond = eval((enableHour * 3600) + (enableMinute * 60) + enableSecond);
                        var totalSecond = eval(pressTotalSecond - enableTotalSecond);
                        
                        if (enableMiliSecond == pressMiliSecond) {

                            var diffMiliSeconds = 0;
                        }

                        else if (enableMiliSecond < pressMiliSecond) {
                            var diffMiliSeconds = eval(pressMiliSecond - enableMiliSecond);
                        }

                        else if (enableMiliSecond > pressMiliSecond) {

                            totalSecond =  eval(totalSecond - 1);
                            var diffMiliSeconds = eval((1000 - enableMiliSecond) + pressMiliSecond);
                        }

                        if (diffMiliSeconds<100) {
                            document.getElementById("buzzer" + value.buzzerNumber + "_time").textContent = totalSecond + '.0' + diffMiliSeconds + ' s';
                        }
                        else {
                            document.getElementById("buzzer" + value.buzzerNumber + "_time").textContent = totalSecond + '.' + diffMiliSeconds + ' s';
                        }
                       
                    }
                    if (value.isFirst) {
                      
                        var audio = new Audio('../audio/wrong-answer-sound-effect.mp3');
                        audio.play();
                        var element = document.getElementById("buzzer" + value.buzzerNumber);
                        //element.classList.remove("btn-primary");
                        //element.classList.add("btn-success");
                        element.classList.add("pressed");
                        
                       

                        document.getElementById("correctButton" + value.buzzerNumber).hidden = false;
                        document.getElementById("wrongButton" + value.buzzerNumber).hidden = false;
                        document.getElementById("notAnsweredButton" + value.buzzerNumber).hidden = false;
                        //document.getElementById("buzzer" + value.buzzerNumber).ad('btn-success');
                    }

                });



            }
        });
    }


    var connection = new signalR.HubConnectionBuilder().withUrl("/signalServer").build();
    connection.on("EnableBuzzer", function (user, message) {
        
        enableBuzzers();
    });
    connection.on("PressBuzzer", function (user, message) {

        pressBuzzer();
    });

    connection.on("DisableBuzzer", function (user, message) {

        disableBuzzers();
    });
    connection.on("StartMcq", function (id) {

        startMcq(id);
    });

    connection.on("StopMcq", function (id) {

        stopMcq(id);
    });
    connection.on("GetMcqResult", function (id) {

        getMcqResult(id);
    });


    
    connection.start().then(function () {

    }).catch(function (err) {

        return console.error(err.toString());
    });

    //var connection1 = new signalR.HubConnectionBuilder().withUrl("/signalServer").build();
    //connection1.on("PressBuzzer", function (user, message) {
    //    getBuzzerTime();
    //});
    //connection1.start().then(function () {

    //}).catch(function (err) {

    //    return console.error(err.toString());
    //});






});
