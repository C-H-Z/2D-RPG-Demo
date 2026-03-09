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
| **游戏管理器** | [GameManager.cs](https://github.com/C-H-Z/2D-RPG-Demo/blob/main/Script/GameManager.cs) | 全局单例，管理游戏状态（如有） |
| **玩家移动** | [PlayerMovement.cs](https://github.com/C-H-Z/2D-RPG-Demo/blob/main/Script/PlayerScripts/PlayerMovement.cs) | 输入处理与移动逻辑 |
| **玩家战斗** | [Player_Combat.cs](https://github.com/C-H-Z/2D-RPG-Demo/blob/main/Script/PlayerScripts/Player_Combat.cs) | 近战攻击、伤害计算 |
| **远程攻击** | [Player_Bow.cs](https://github.com/C-H-Z/2D-RPG-Demo/blob/main/Script/PlayerScripts/Player_Bow.cs) | 弓箭射击逻辑 |
| **属性管理器** | [StatsManager.cs](https://github.com/C-H-Z/2D-RPG-Demo/blob/main/Script/PlayerScripts/StatsManager.cs) | **单例模式**，管理生命、伤害等属性 |
| **经验系统** | [ExpManager.cs](https://github.com/C-H-Z/2D-RPG-Demo/blob/main/Script/PlayerScripts/ExpManager.cs) | 经验获取与升级 |
| **玩家生命** | [PlayerHealth.cs](https://github.com/C-H-Z/2D-RPG-Demo/blob/main/Script/PlayerScripts/PlayerHealth.cs) | 受伤、死亡处理 |
| **装备更换** | [Player_ChangeEquipment.cs](https://github.com/C-H-Z/2D-RPG-Demo/blob/main/Script/PlayerScripts/Player_ChangeEquipment.cs) | 装备切换逻辑 |
| **属性UI** | [StatsUI.cs](https://github.com/C-H-Z/2D-RPG-Demo/blob/main/Script/PlayerScripts/StatsUI.cs) | 属性面板显示 |
| **弓箭逻辑** | [Arrow.cs](https://github.com/C-H-Z/2D-RPG-Demo/blob/main/Script/PlayerScripts/Arrow.cs) | 投射物行为 |

| **背包管理器** | [InventoryManager.cs](https://github.com/C-H-Z/2D-RPG-Demo/blob/main/Script/Inventory%20&%20Shop/InventoryManager.cs) | **单例模式**，物品管理 |
| **物品数据** | [ItemSO.cs](https://github.com/C-H-Z/2D-RPG-Demo/blob/main/Script/Inventory%20&%20Shop/ItemSO.cs) | **ScriptableObject**，物品配置 |
| **背包格子** | [InventorySlot.cs](https://github.com/C-H-Z/2D-RPG-Demo/blob/main/Script/Inventory%20&%20Shop/InventorySlot.cs) | UI格子逻辑 |
| **掉落系统** | [Loot.cs](https://github.com/C-H-Z/2D-RPG-Demo/blob/main/Script/Inventory%20&%20Shop/Loot.cs) | 敌人死亡掉落 |
| **物品使用** | [UseItem.cs](https://github.com/C-H-Z/2D-RPG-Demo/blob/main/Script/Inventory%20&%20Shop/UseItem.cs) | 使用物品效果 |

| **技能树管理器** | [SkillTreeManager.cs](https://github.com/C-H-Z/2D-RPG-Demo/blob/main/Script/SkillTree/SkillTreeManager.cs) | **单例模式**，技能解锁 |
| **技能管理器** | [SkillManager.cs](https://github.com/C-H-Z/2D-RPG-Demo/blob/main/Script/SkillTree/SkillManager.cs) | 技能效果应用 |
| **技能数据** | [SkillSO.cs](https://github.com/C-H-Z/2D-RPG-Demo/blob/main/Script/SkillTree/SkillSO.cs) | **ScriptableObject**，技能配置 |
| **技能格子** | [SkillSlot.cs](https://github.com/C-H-Z/2D-RPG-Demo/blob/main/Script/SkillTree/SkillSlot.cs) | UI格子逻辑 |
| **技能开关** | [ToggleSkillTree.cs](https://github.com/C-H-Z/2D-RPG-Demo/blob/main/Script/SkillTree/ToggleSkillTree.cs) | 打开/关闭技能树 |


## 快速开始
1. 克隆仓库：`git clone https://github.com/C-H-Z/2D-RPG-Demo.git`
2. 用 Unity Hub 打开项目文件夹
3. 打开示例场景开始运行
