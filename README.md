# EstimoteSample

Unity project showing how to obtain data from Estimote sensors, through gateway
<https://github.com/cwi-dis/iotsaEstimotes>.

The gateway is a wifi-enabled REST server running on an ESP32. It uses BlueTooth LE
to obtain sensor readings from a number of Estimote sensors that are near to it.

The data is provided to the Unity app using REST over HTTP over TCP/IP over WiFi,
so the Unity app only needs to use a module that can speak HTTP. No need for direct
Bluetooth LE access in the Unity app.

## Gateway setup

You will need to tell the gateway (the esp32 lolin board) your WiFi network and password:

- connect the board to power.
- It will not find the old WiFi network it was connected to. Therefore it will create a network itself, with the name `config-estimotes`.
- Join that network with your laptop or mobile phone.
- Open a browser, go to <http://estimotes.local>, check the board is working.
- Goto <http://estimotes.local/config>. 
- Select `Enter configuration mode after next reboot.`, press `Submit`.
- Press the little _Reset_ button on the board, or power cycle the board.
- go to <http://estimotes.local>. It should now say something like `In configuration mode configuration, will timeout in 291 seconds.`.
- go to `/wificonfig` and enter your WiFi network name and password. Press submit.
- The board should reboot and connect to the correct WiFi network. But maybe you have to power cycle it once more.
- Reconnect your laptop to your normal wifi network, and ensure you can still access <http://estimotes.local>.
- Now put a battery in the estimote, and at <http://estimotes.local/estimote> you can see the current state of the estimote.

## Project structure

The `EstimoteSample` scene has everything:

- `EstimoteTracker` talks to the tracker. At the moment it gets a reading from a single estimote, and an interval that you can control. The `URL` field is where the data is gotten from.
- `Dice_d6_blablabla` has the dice, and the `SimpleDiceBehaviour` controls it.
