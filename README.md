
# Unity Input Path HID

This package allows you to retrieve the HID value of a device in Unity and convert it into boolean events.

Note: Unity messed up the Input System in December 2025, breaking my workshop and my project.
So I went back to the old code and started reading input paths directly until it’s fixed:
[https://discussions.unity.com/t/inputactionreference-not-saved-on-prefab/1699980/16](https://discussions.unity.com/t/inputactionreference-not-saved-on-prefab/1699980/16)



Note: I started refactoring, but when I connected four NES controllers, only the last one actually received HID input.  
I’ve since switched to Godot because I’m exhausted by this nonsense.   
In December 2025, Unity broke the Input System and turned my day into a dumpster fire by breaking every prefab in my package. I was planning to use the HID tool I had started designing, but Unity apparently decided to sabotage whatever code sits underneath it.    
I’m done for now.  
If you’re sticking with Unity, just use Rewired:   
https://assetstore.unity.com/packages/tools/utilities/rewired-21676  

Unity is embarrassing. Every time it tries to replicate an Asset Store solution, it fails spectacularly.  