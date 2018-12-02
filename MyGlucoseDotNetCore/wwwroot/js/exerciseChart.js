﻿$(document).ready(function () {

    google.charts.load('current', { 'packages': ['line'] });
    google.charts.setOnLoadCallback(drawChart);

    function drawChart() {

        $url = "/API/ChartApi/GetUserExerciseChart?UserName=" + $.urlParam("UserName");
        console.log("Sending request: [href: " + $url + "]" + ";");

        $.ajax({
            url: $url,
            method: 'get',
            beforeSend: function () {
                //$link.addClass('overlay');
            },
            success: function (response) {
                console.log(response);

                var exerciseArray = [["Date", "Minutes"]];
                $.each(response.exerciseEntries, function () {
                    var exerciseItem = [this.updatedAt, this.minutes];
                    exerciseArray.push(exerciseItem);
                });

                var gData = google.visualization.arrayToDataTable(exerciseArray);
                var data = new google.visualization.DataTable();
                gData.addColumn('date', 'Date');
                gData.addColumn('number', 'Minutes');

                var options = {
                    chart: {
                        title: 'Exercise Over Time'//,
                        //subtitle: 'in millions of dollars (USD)'
                    },
                    width: 900,
                    height: 500
                };

                var chart = new google.charts.Line(document.getElementById('linechart_material'));

                if (exerciseArray.length > 0)
                    chart.draw(gData, google.charts.Line.convertOptions(options));

                //let $div = $('#feat_' + response.featureId);
                //$div.remove();                              // Delete the row entirely
            },
            error: function (response) {
                console.log(response);
                //$link.removeClass('overlay');
            }
        });

    } // drawChart


    // From: https://stackoverflow.com/a/25359264
    $.urlParam = function (name) {
        var results = new RegExp('[\?&]' + name + '=([^&#]*)').exec(window.location.href);
        if (results === null) {
            return null;
        }
        return decodeURI(results[1]) || 0;
    } // urlParam

}); // document onLoad