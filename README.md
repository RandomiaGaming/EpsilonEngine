# EpsilonEngine
EpsilonEngine is a 2D pixel game engine designed to provide a simple way to create games for Windows.
It is built against the directX rendering engine and a custom made physics engine.
The physics engine is designed to work with pixel perfect hitboxes and avoid common issues like clipping through thin hitboxes
or framerate dependent interactions. EpsilonEngine is also highly optimized to be able to achive over 500 fps even on low end hardware.

# EpsilonEngine is in unfinished beta!

EpsilonEngine's development is designed around the following goals:
1. Games should be playable for everyone regardless of hardware specs.
2. Games should be accessable to everyone regardless of mental or physical disabilities.
3. Physics should be consistent across different computers and play-sessions.

How do we achive these goals?
1. EpsilonEngine is highly optimized and compatibility with all types of hardware is always a priority.
We have worked hard to ensure that games run smoothly on all recent versions of Windows including 8, 10, and 11.
2. EpsilonEngine features keyboard remapping right out of the box to ensure everyone can control games the way they want to.
We also support all types of input devices including game controllers, and accessable input devices. We have worked hard to
include tools that developers can use to make their games accessable to those who are visually impaired and we have an
accessibility handbook with tips for making your games more accessable and fun for everyone.
3. Our in house custom physics engine is framerate dependent which means regardless of your computer specs or FPS physics
is always consistent. In addition collisions are checked using a modified raycast algorithem which prevents objects from
clipping through or into each other regardless of speed or the shape of hitbox. This means you are free to create small hitboxes
or have objects travel at break-neck speeds without fear of clipping. In addition the physics engine will behave consistantly
regardless of the processing order of objects which means you can spend more time coding and less time debugging.

Technical Notes:
EpsilonEngine is created using .NetFramework 4.8 and SharpDX it uses a custom in house solution for input based upon the
Win32 RawInput APIs using PInvoke. It also uses a custom in house physics engine. For audio it uses a custom audio library
built upon the Win32 WASAPI using PInvoke.