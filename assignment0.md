# Assignment 0

- [ ] Mercury
- [x] Venus
- [x] Earth (Orbit/Moon)
- [x] Mars

**What do the different options for World Center Mode mean?**

- *FIRST_TARGET = the first image target detected becomes center of the world i.e. the coordinate system.*
- *SPECIFIC_TARGET = a specific image target is center of the world or coordinate system.*

**Why is it important to have correct measures for your image targets when uploading them to Vuforia?**

- *The target size parameter is important, since the pose information returned during tracking will be in the same scale. For example, if the target image is 16 units wide, then moving the camera from the left border of the target to the right border of the target changes the returned position by 16 units along the x-axis.*
  - *(x, y) - Target size in scene units measured along the horizontal and vertical axes of the rectangular target.*
