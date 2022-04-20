you **MUST** use Unity **v2021.2.X**.

###### Playtesting sessions:

​	Feb25, Mar25, Apr15



###### Industry Discussion Topics => Pre => Mar 30

Topics already covered: 

(a)summarise topic 

(b)relevance to game creators

(c) extrapolate future impact

(d) provide sources

www.gamedeveloper.com

YouTube search ```gdc```



Q#'s due will one week after

Website: http://robmsantos.com/teaches/unity/vg0_upload.html

Student Plan: https://unity.com/products/unity-student

Advice:

​	Always trust **default** in Unity!

​	Learn something only by need!

​	Group size $\le$ 4, 4 => student plan

To change your **editor**, 

![螢幕截圖 2022-01-27 21.16.20](/Users/stevenwong/Library/Application Support/typora-user-images/螢幕截圖 2022-01-27 21.16.20.png)

![螢幕截圖 2022-01-27 21.15.41](/Users/stevenwong/Library/Application Support/typora-user-images/螢幕截圖 2022-01-27 21.15.41.png)

Core loop: Input => action => obstacles => goals

Function name convention: `Funxxx` instead of `funxxx`

Search for `order of execution for event functions`

Sprite sheet => dozens of image

Rigidbody 2D => mass 1 = 1kg, linear drag = air resistance 

https://kenney.nl for free stuff



###### **2/2**

Point filter

Separate a sprite sheet into several pieces:

`sprite mode => multiple => sprite editor => slicing => type = automatic`

Game screen size => fix!!! => 16:9

Use Physics => Rigidbody2D => linear drag = 1(air resistance) => angular drag = 2

Physical shape => collider (e.g. box collider 2D)



###### **2/7**

Declare variable using public => can edit it in unity + rotation & move forward



###### 2/9

A collide b or b collide a are the **same**!

Do not use `typeof(other.gameobject)`, instead, use `other.gameobject.getcomponent<xxx>`

`using UnityEngine.SceneManagement` => use `SceneManager.LoadScene(xxx)`

=> xxx is `GetActiveScene().name` => goto file => build settings => add scene => drag or click `add open scenes`

Starting Q3:

​	Quest linkage: Q3 => Q4 => Q7

​	Layers & Tags

![Screenshot 2022-02-27 at 20.55.46](/Users/stevenwong/Library/Application Support/typora-user-images/Screenshot 2022-02-27 at 20.55.46.png)

![Screenshot 2022-02-27 at 20.56.23](/Users/stevenwong/Library/Application Support/typora-user-images/Screenshot 2022-02-27 at 20.56.23.png)

Prefabs (just like template in C++) => override & prefab editor



###### **2/14**

Files => build settings 

38"00 WebGL setting => itch.io and how to use

Collider set to `is trigger` => then can go across it



###### **2/16**

Center vs Pivot mode

Unity uses left-bottom coordinate system

How to projectile keys



![Screenshot 2022-02-28 at 03.43.00](/Users/stevenwong/Library/Application Support/typora-user-images/Screenshot 2022-02-28 at 03.43.00.png)



###### **2/21**

How to jump 

Raycast will detect the first object you cross thru line

Raycastall ... all ...

=> Start Q4:

![Screenshot 2022-03-01 at 01.07.57](/Users/stevenwong/Library/Application Support/typora-user-images/Screenshot 2022-03-01 at 01.07.57.png)

22 min left to watch

Tilepalettes & tile

 

###### **2/23**

Alt + Mouse => drag

Tilemap collider 2d

Edge collider 2d (use by effector) + platform effector 2d

3 kinds of animation:



###### **2/28**

How to create animation using animator



###### **3/2** 

Q5

For Rigidbody 2D:

1. Static => unmovable

2. Dynamic => real world
3. kinematic => mix of 1 & 2















