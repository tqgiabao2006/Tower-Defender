# 🪴 Plant Defender - *A Pixel Art Tower Defender Game*

![Logo]()

[![Unity](https://img.shields.io/badge/Made_with-Unity-000?logo=unity&style=for-the-badge)](https://unity.com/)  
[![GitHub Repo](https://img.shields.io/badge/View_on-GitHub-blue?style=for-the-badge&logo=github)](https://github.com/tqgiabao2006/Tower-Defender)

---

## 🚀 Game Overview  
*Plant Defender* is a **tower defender game** in which player build plants to project village from enemies. It is strongly influenced by two largest tower defenders is *Kingdom Rush* and *PlantVsZombie*

### 🎯 Key Features
- ♻️ **Object Pooling** – Reuses disabled bullets
- 🪴 **Plants' placements and shooting**  
- ⚙️ **Simple AI Behavior**
- ⏫ **Plants' Upgrade**
- 🎨 **Self-made Pixel Art Asset**
---

### 📌 Details

## ♻️ Object Pooling

**Object Pooling in Game Development**

Object Pooling is a design pattern used to manage object creation and reuse efficiently. Instead of frequently instantiating and destroying objects, which can be costly in terms of performance, a pool of pre-instantiated objects is maintained. When an object is needed, it is retrieved from the pool, and when it is no longer in use, it is returned to the pool instead of being destroyed.

**Why Use Object Pooling?**

In game development, performance optimization is critical, especially when dealing with frequent object instantiation and destruction, such as bullets, enemies, or particles. Object Pooling helps reduce garbage collection overhead and improves runtime efficiency by reusing objects instead of creating and destroying them frequently.

**Benefits of Object Pooling**
- **Performance Improvement**: Reduces CPU overhead from frequent object instantiations and garbage collection.
- **Garbage Collection Reduction**: Since objects are reused, memory allocations and deallocations are minimized, reducing GC spikes.
- **Better Frame Rate Stability**: Prevents performance hiccups caused by object creation and destruction, leading to a smoother gameplay experience.
- **Efficient Memory Management**: Controls the number of active objects, reducing memory fragmentation.


## Implementation in Plant Defender in Unity (C#)
```csharp
public class ObjectPooling : MonoBehaviour
{
   private static ObjectPooling _instant;
   public static ObjectPooling Instant => _instant;

   Dictionary<GameObject, List<GameObject>> _pool = new Dictionary<GameObject, List<GameObject>>();

   void Awake()
   {
      _instant = this; 
   }
   public virtual GameObject GetObj(GameObject prefabs)
   { 
      List<GameObject> listObj = new List<GameObject>();
     if(_pool.ContainsKey(prefabs))
        listObj = _pool[prefabs];

      else
      {
         _pool.Add(prefabs, listObj);
      }
       
      foreach(GameObject g in listObj)
      {
         if(g.activeSelf)
         continue;
         return g;
      }
      GameObject g2 = Instantiate(prefabs, this.transform.position, Quaternion.identity);
      listObj.Add(g2);
      return g2;
   }
}
```

---

## 🪴 Plant
**Key features:**
- A `Plant Base` class fore all children plant classes to inherent with similar variables, and functions such as `Shooting()`, `Upgrade()`
- The plant shoot by using `Physics2D.OverlapCircleAll()` to check for enemies within the range. If true, call `Shooting()`
- Player can water plants for them to upgrade

**Sample stat of a plan**

![SampleStat]()

---

## 🎨Self-made Pixel Art Asset








---
## 🎥 Demo Gameplay Video
![Gameplay Preview](https://github.com/tqgiabao2006/Blood-vein/raw/main/ReadMe/Gameplay.gif)

---

## 🛠 Tech Stack  
| **Technology**   | **Usage**  |  
|-----------------|-----------|  
| Unity (C#) | Core Engine & Gameplay |  
| Shader Graph | Visual Effects & Water Rendering |  
| A* Algorithm | Pathfinding |  
| ECS (Entity Component System) | Multi-threading Performance |  

---

## 🏗 Design Patterns Used  
✔ **Observer Pattern** – Event-driven architecture for game logic.  
✔ **State Pattern** – AI and game state transitions.  
✔ **Factory Pattern** – Dynamic object creation.  
✔ **Unity Test Framework** – Ensures stability and correctness.  

---

## 🎮 Current Status  
📦 **Developing**

---

## 🚧 Development Roadmap  
🔹 **[ ] Multiplayer Mode** – Co-op city building.  
🔹 **[ ] Improved AI Steering** – Smarter vehicle movement.  
🔹 **[ ] Procedural Environment** – Dynamic terrain growth.  
🔹 **[ ] Transition to 3D Perspective**  

---

## 🏆 Contributors & Credits  
👨‍💻 **Ben** (*Mad Scientist of Game Lab*) – Solo Developer  
🎵 **Music & SFX:** Open-source / Custom Compositions  
📖 **Special Thanks:** [Unity Vietnam Community], and Senior Game Artist Tung Anh as an advisor  

---

## ⭐ Support & Feedback  
💬 **Have feedback?** Open an [issue](https://github.com/tqgiabao2006/Tower-Defender/issues) or contact me via email: tqgiabao2006@gmail.com.  
🎮 **Follow my journey:** [🔗 Portfolio](https://your-portfolio-link.com)  
