﻿UltraDynamo
-----------
Author: David Auld
Copyright: David Auld ©2012
Website: http://www.dave-auld.net/

Version: 1.1.0.0 - Date: 14th December 2012
-------------------------------------------
This was a quick interim release to fix an issue relating to installer package. Opportunity also taken to address a couple of
other issues with the application as detailed below.

New Features:
Simulator capabilities for Accelerometer, Compass, Gyrometer, Inclinometer, Light Sensor

Changes:
Enabled double buffering on the GUI controls to reduce/stop flickering. This was an oversight in the intial release.
Reworked the sensor handling.

Fixes:
None.

Known Issues:
1) as per previous version below.


Version: 1.0.0.0 - Date: 13th November 2012
-------------------------------------------
New Features: All New. First Release of Application as part of the Intel AppUp Competition.

Changes: none.

Fixes: mone.

Known Issues:
1) There appears to be an underlying issue with the GPS Sensor. This has been discussed on the internet at;
	a) http://software.intel.com/en-us/forums/topic/332589
	b) http://www.codeproject.com/script/Awards/View.aspx?cid=598&msg=4412294#xx4412294xx

	This may prevent the Speedometer and Net Horsepower functions from working. If the issue is resolved with a driver fix, the
	displays may start to work, but at present, they have not been fully tested due to the underlying fault.
