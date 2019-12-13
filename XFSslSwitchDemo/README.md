Xamarin.Forms enabling insecure HTTP Communication demo
===========

Enable on Android:

AndroidManifest.xml
<application 
android:label="XF SSL Demo" 
android:networkSecurityConfig="@xml/network_security_config">
</application>

Create file: Resources/xml/network_security_config.xml
<?xml version="1.0" encoding="utf-8"?>
<network-security-config>
  <base-config cleartextTrafficPermitted="true" />
</network-security-config>

Enabled on iOS:

<key>NSAppTransportSecurity</key>
<dict>
	<key>NSAllowsArbitraryLoads</key>
	<true/>
</dict>