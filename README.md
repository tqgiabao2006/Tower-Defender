# 🎮 Plant Defender - *A Pixel Art Tower Defender Game*

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

#### ♻️ Object Pooling
# Object Pooling in Game Development

Object Pooling is a design pattern used to manage object creation and reuse efficiently. Instead of frequently instantiating and destroying objects, which can be costly in terms of performance, a pool of pre-instantiated objects is maintained. When an object is needed, it is retrieved from the pool, and when it is no longer in use, it is returned to the pool instead of being destroyed.

## Why Use Object Pooling?
In game development, performance optimization is critical, especially when dealing with frequent object instantiation and destruction, such as bullets, enemies, or particles. Object Pooling helps reduce garbage collection overhead and improves runtime efficiency by reusing objects instead of creating and destroying them frequently.

## Benefits of Object Pooling
- **Performance Improvement**: Reduces CPU overhead from frequent object instantiations and garbage collection.
- **Garbage Collection Reduction**: Since objects are reused, memory allocations and deallocations are minimized, reducing GC spikes.
- **Better Frame Rate Stability**: Prevents performance hiccups caused by object creation and destruction, leading to a smoother gameplay experience.
- **Efficient Memory Management**: Controls the number of active objects, reducing memory fragmentation.

## Drawbacks of Object Pooling
- **Memory Consumption**: A pool reserves memory for objects that might not always be in use.
- **Complexity**: Implementing and managing an object pool requires additional logic to handle object reuse correctly.
- **Not Always Necessary**: If objects are not frequently created or destroyed, pooling might not provide noticeable benefits and could add unnecessary complexity.

## When to Use Object Pooling?
- When dealing with high-frequency object instantiation/destruction (e.g., bullets, enemies, particle effects).
- When performance optimization is required due to GC spikes.
- In systems where memory fragmentation needs to be controlled.

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

![Grid Image](https://github.com/tqgiabao2006/Blood-vein/raw/main/ReadMe/BloodVein_Grid.png)

*Grid image, with red color indicating an unwalkable node.*

![Heap Image](https://github.com/tqgiabao2006/Blood-vein/raw/main/ReadMe/Heap.png)

*Heap interface to optimize the pathfinding algorithm.*
 
---

#### **2. 🤖 A* Pathfinding Algorithm**
A* (A-Star) is a widely used **graph traversal and pathfinding algorithm** that finds the **shortest path** from a starting point to a target.

**✨ How It Works**
A* combines:
- **G(n)** → The actual cost from the start node to the current node.
- **H(n)** → The estimated cost (heuristic) from the current node to the goal.
- **F(n) = G(n) + H(n)** → The total estimated cost of the path.

The algorithm **prioritizes nodes with the lowest `F(n)`**, ensuring an optimal and efficient path.  

**🕹 Application in Blood Vein**  
In **Mining**, A* is used for **vehicle movement and network optimization**, allowing mining cars to navigate efficiently.

**📌 Why A***  
✔ **Optimal & Efficient** – Finds the shortest path with minimal cost.  
✔ **Heuristic-Based** – Can be tuned for different movement styles.  
✔ **Scalable** – Works for both simple grids and complex road networks.  
✔ **Realistic and Random** – Can be modified with random variations to create more realistic behavior.  

---

#### **3. ⚙️ Procedural Mesh Generation**
- **Road Mesh:**
  - Pre-calculates four standard shape types with different angles: 180° (continuous road), 135°, 90° (corner road), and 45°.
  - Uses an enum **Direction**, assigned with bitwise integers to merge directions. Iterates through a node's neighbor list and calculates the direction between them.
  - Determines the number of standard shapes required, then rotates them accordingly.

![Bitwise Direction](https://github.com/tqgiabao2006/Blood-vein/raw/main/ReadMe/Enum%20Direction.png)

![Get Baked Directions](https://github.com/tqgiabao2006/Blood-vein/raw/main/ReadMe/Get%20direction.png)

  - Finally, uses polar coordinates to create smooth curves at sharp angles.

![Curve Mesh](https://github.com/tqgiabao2006/Blood-vein/raw/main/ReadMe/Smooth%20curve.png)

- **Parking Lot Mesh:**
  - Creates a rounded rectangle based on the building's size and direction.

---

#### **4. 🔀 Multi-threading with ECS**
- **Why Use It?**
  - **Performance**: Needed to handle large amounts of AI-driven entities (mining cars, roads) efficiently.
  - **Scalability**: Ensures smooth performance as complexity grows.
  - **Multithreading**: Avoids performance bottlenecks in pathfinding and vehicle movement.

- **How It Was Applied:**
  - **ECS (Entity Component System)**: Decouples game data (position, speed, etc.) from logic, improving memory usage and CPU performance.
  - **Multithreading**: Distributes intensive tasks across multiple CPU cores, maintaining **1000+ FPS** even with **1000 cars**.
  - **Burst Compiler**: Optimizes performance-critical code, improving runtime execution efficiency.

### **Drawbacks**
- **Complexity**: DOTS requires a new approach to game architecture, increasing development difficulty.
- **Debugging Challenges**: Multithreading introduces race conditions and synchronization issues.
- **Imperfect for Uncertain Data**: User-defined data types that change unpredictably can cause issues in road calculations and building placement.

![ECS](https://github.com/tqgiabao2006/Blood-vein/raw/main/ReadMe/ECS.png)

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
💬 **Have feedback?** Open an [issue](https://github.com/tqgiabao2006/blood-vein/issues) or contact me via email: tqgiabao2006@gmail.com.  
🎮 **Follow my journey:** [🔗 Portfolio](https://your-portfolio-link.com)  
