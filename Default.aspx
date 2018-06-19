<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="content-type" content="text/html; charset=UTF-8" />
    <title>Google Maps Multiple Markers</title>
    <script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyBkZScUN1Kxcpl9CSAnHxncPbKeW2oMCq0" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <p hidden="hidden" id="information" runat="server"></p>
            <p hidden="hidden" id="st" runat="server"></p>
        </div>

        <div id="map" style="width: 800px; height: 700px;"></div>

        <script type="text/javascript">
            var check = false;
            var array = document.getElementById("information").innerHTML;
            var array2 = document.getElementById("st").innerHTML;
            var newarray = array.split(",");
            var newarray2 = array2.split(",");
            function listToMatrix(list, elementsPerSubArray) {
                var matrix = [], i, k;

                for (i = 0, k = -1; i < list.length; i++) {
                    if (i % elementsPerSubArray === 0) {
                        k++;
                        matrix[k] = [];
                    }

                    matrix[k].push(list[i]);
                }
                return matrix;
            }
            var matrix = listToMatrix(newarray, 3);
            var matrix2 = listToMatrix(newarray2, 1);
            var stts = matrix2;
            var locations = matrix;
            var map = new google.maps.Map(document.getElementById('map'), {
                zoom: 12,
                center: new google.maps.LatLng(23.757278, 90.3894735),
                mapTypeId: google.maps.MapTypeId.ROADMAP
            });

            var infowindow = new google.maps.InfoWindow();

            var marker, i;

            for (i = 0; i <= locations.length; i++) {
                var schoolname = locations[i][0];
                if (stts[i][0] === "True") {
                    marker = new google.maps.Marker({
                        position: new google.maps.LatLng(Number(locations[i][1]), Number(locations[i][2])),
                        map: map,
                        title: schoolname,
                        icon: 'green.png'
                    });
                }

                else {
                    marker = new google.maps.Marker({
                        position: new google.maps.LatLng(Number(locations[i][1]), Number(locations[i][2])),
                        map: map,
                        title: schoolname,
                        icon: 'red.png'
                    });
                }


                google.maps.event.addListener(marker, 'click', (function (marker, i) {
                    return function () {
                        infowindow.setContent("School Name: " + locations[i][0]);
                        infowindow.open(map, marker);
                    }
                })(marker, i));
            }
        </script>
    </form>
</body>
</html>

