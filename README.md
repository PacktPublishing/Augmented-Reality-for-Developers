# Augmented Reality for Developers
This is the code repository for [Augmented Reality for Developers](https://www.packtpub.com/web-development/augmented-reality-developers?utm_source=github&utm_medium=repository&utm_campaign=9781787286436), published by [Packt](https://www.packtpub.com/?utm_source=github). It contains all the supporting project files necessary to work through the book from start to finish.
## About the Book
Augmented Reality brings with it a set of challenges that are unseen and unheard of for traditional web and mobile developers. This book is your gateway to Augmented Reality development—not a theoretical showpiece for your bookshelf, but a handbook you will keep by your desk while coding and architecting your first AR app and for years to come.

The book opens with an introduction to Augmented Reality, including markets, technologies, and development tools. You will begin by setting up your development machine for Android, iOS, and Windows development, learning the basics of using Unity and the Vuforia AR platform as well as the open source ARToolKit and Microsoft Mixed Reality Toolkit. You will also receive an introduction to Apple's ARKit and Google's ARCore! You will then focus on building AR applications, exploring a variety of recognition targeting methods. You will go through multiple complete projects illustrating key market sectors including business marketing, education, industrial training, and gaming.

By the end of the book, you will have gained the necessary knowledge to make quality content appropriate for a range of AR devices, platforms, and intended uses.
## Instructions and Navigation
All of the code is organized into folders. Each folder starts with a number followed by the application name. For example, Chapter02.

Chapters 1, 2, and 3 don't have code files.

The code will look like the following:
```
public GameObject defaultPictureObject;
    public float spawnDistance = 2.0f;
    public void CreateNewPicture() {
        Vector3 headPosition = Camera.main.transform.position;
        Vector3 gazeDirection = Camera.main.transform.forward;
        Vector3 position = headPosition + gazeDirection * spawnDistance;

        Quaternion orientation = Camera.main.transform.localRotation;
        orientation.x = 0;
        orientation.z = 0;
        GameObject newPicture = Instantiate(defaultPictureObject, position, orientation);
        newPicture.tag = "Picture"; 
    } 

```

Requirements will depend on what you are using for a development machine, preferred AR toolkit, and target device. We assume you are developing on a Windows 10 PC or on a macOS. You will need a device to run your AR apps, whether that be an Android smartphone or tablet, an iOS iPhone or iPad, or Microsoft HoloLens. All the software required for this book are described and explained in Chapter 2, Setting Up Your System, and Chapter 3, Building Your App, which include web links to download what you may need. Please refer to Chapter 3, Building Your App, to understand the specific combinations of development OS, AR toolkit SDK, and target devices supported.

## Related Products
* [Augmented Reality for Android Application Development](https://www.packtpub.com/application-development/augmented-reality-android-application-development?utm_source=github&utm_medium=repository&utm_campaign=9781782168553)

* [Augmented Reality with Kinect](https://www.packtpub.com/application-development/augmented-reality-kinect?utm_source=github&utm_medium=repository&utm_campaign=9781849694384)

* [Augmented Reality Game Development](https://www.packtpub.com/application-development/augmented-reality-game-development?utm_source=github&utm_medium=repository&utm_campaign=9781787122888)

