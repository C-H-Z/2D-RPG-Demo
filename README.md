# 2D-RPG-Demo

一个专注于游戏架构设计的 2D RPG Unity 项目。

## 项目概览
该项目实现了模块化架构，其中每个游戏系统独立运行，并通过事件和单例管理器进行通信。这种设计促进了关注点分离，使代码库易于维护和扩展。

该架构展示了贯穿整个项目的三个核心设计模式：用于全局状态管理的单例模式、用于数据驱动配置的 ScriptableObject 模式，以及用于解耦系统交互的基于事件的通信。

## 核心模块
- **玩家系统**：玩家移动与输入处理 (`PlayerMovement.cs`)、战斗系统 (`Player_Combat.cs`)
- **敌人 AI**：敌人移动 (`Enemy_Movement.cs`)、战斗逻辑 (`Enemy_Combat.cs`)
- **属性管理**：状态管理器 (`StatsManager.cs`)、经验系统 (`ExpManager.cs`)
- **物品与商店**：物品系统 (`InventoryManager.cs`)、战利品 (`Loot.cs`)
- **技能系统**：技能树管理 (`SkillTreeManager.cs`)、技能配置 (`SkillSo.cs`)
- **场景管理**：场景切换 (`SceneChange.cs`)

## 技术栈
- Unity 2022.3 LTS
- C# 脚本
- ScriptableObject 数据驱动设计
- 单例模式架构

## 📂 核心代码快速入口

| 模块 | 代码位置 | 说明 |
|:---|:---|:---|
| 游戏管理器 | [GameManager.cs](Assets/Scripts/GameManager.cs) | 全局单例，管理游戏状态 |
| 玩家控制 | [PlayerMovement.cs](Assets/Scripts/PlayerMovement.cs) | 输入处理与移动逻辑 |
| 战斗系统 | [Player_Combat.cs](Assets/Scripts/Player_Combat.cs) | 攻击、伤害计算 |
| 背包系统 | [InventoryManager.cs](Assets/Scripts/Inventory&Shop/InventoryManager.cs) | 物品管理，单例实现 |
| 技能树 | [SkillTreeManager.cs](Assets/Scripts/SkillTree/SkillTreeManager.cs) | 技能解锁与升级 |
| 敌人AI | [Enemy_AI.cs](Assets/Scripts/Enemy_AI.cs) | 状态机实现 |

## 快速开始
1. 克隆仓库：`git clone https://github.com/C-H-Z/2D-RPG-Demo.git`
2. 用 Unity Hub 打开项目文件夹
3. 打开示例场景开始运行
