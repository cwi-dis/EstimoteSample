# EstimoteSample

Unity project showing how to obtain data from Estimote sensors, through gateway
<https://github.com/cwi-dis/iotsaEstimotes>.

The gateway is a wifi-enabled REST server running on an ESP32. It uses BlueTooth LE
to obtain sensor readings from a number of Estimote sensors that are near to it.

The data is provided to the Unity app using REST over HTTP over TCP/IP over WiFi,
so the Unity app only needs to use a module that can speak HTTP. No need for direct
Bluetooth LE access in the Unity app.
