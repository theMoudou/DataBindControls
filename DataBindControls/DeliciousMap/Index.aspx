<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="DeliciousMap.Index" %>

<!DOCTYPE html>
<html>
<head>
    <title>Simple Map</title>
    <script src="https://polyfill.io/v3/polyfill.min.js?features=default"></script>
    <script src="./JavaScript/Modules/index.js"></script>
    <style>
        /* Always set the map height explicitly to define the size of the div
* element that contains the map. */
        #map {
            height: 100%;
        }

        /* Optional: Makes the sample page fill the window. */
        html,
        body {
            height: 100%;
            margin: 0;
            padding: 0;
        }
    </style>
    <script>
        let map;
        var marker2;

        function initMap() {
            var myLatLng = {
                lat: 23.000391753871927,
                lng: 120.21215414087199
            };
            map = new google.maps.Map(document.getElementById("map"), {
                center: myLatLng,
                zoom: 16,
            });

            var contentString = "<h1>標記一</h1><p>簡介內容...簡介內容...</p>";
            const infowindow = new google.maps.InfoWindow({
                content: contentString,
            });

            var marker1 = new google.maps.Marker({
                position: myLatLng,
                map,
                title: "媽！我在這！～!",
            });

            marker1.addListener("mouseover", () => {
                infowindow.open({
                    anchor: marker1,
                    map,
                    shouldFocus: false,
                });
            });

            marker1.addListener("mouseout", () => {
                infowindow.close();
            });

            marker2 = new google.maps.Marker({
                position: {
                    lat: 23.002,
                    lng: 120.214
                },
                map,
                title: "第二標記!",
                icon: "icon01.png"
            });

            marker2.addListener("click", () => {
                infowindow.close();
            });
        }

        function goHome() {
            map.setCenter({
                lat: 23.000391753871927,
                lng: 120.21215414087199
            }
            );
        }
        function movePos() {
            marker2.setPosition(
                {
                    lat: 22.970,
                    lng: 120.214
                }
            );
        }
    </script>
</head>
<body>
    <h1>美食地圖</h1>
    <button onclick="goHome();">搭貓車</button>
    <button onclick="movePos();">換位</button>
    <div id="map"></div>

    <!-- Async script executes immediately and must be after any DOM elements used in callback. -->
    <script
        src="https://maps.googleapis.com/maps/api/js?key=AIzaSyBA9A_Ry9G67EMNHQHYwh3aAE9ubAkaLdU&callback=initMap&v=weekly"
        async></script>
</body>
</html>
