# 🎮 2D-RPG-Demo

一个专注于**游戏架构设计**的 2D RPG Unity 项目，展示模块化、设计模式在实际游戏开发中的应用。

[![Unity Version](https://img.shields.io/badge/Unity-2022.3_LTS-blue)](https://unity.com/)
[![C#](https://img.shields.io/badge/C%23-Scripts-green)](https://docs.microsoft.com/en-us/dotnet/csharp/)
[![License](https://img.shields.io/badge/License-MIT-yellow)](LICENSE)

---

## 📋 项目概览

该项目采用**模块化架构**设计，每个游戏系统独立运行，通过单例管理器和事件系统进行通信，实现关注点分离，使代码库易于维护和扩展。

### 🏗️ 核心设计模式

| 模式 | 应用场景 | 示例 |
|:---|:---|:---|
| **单例模式** | 全局管理器，保证唯一实例 | `GameManager`、`InventoryManager`、`StatsManager`、`SkillTreeManager` |
| **ScriptableObject** | 数据驱动配置，无需修改代码 | `ItemSO`、`SkillSO` 及各种 `.asset` 配置文件 |
| **模块化设计** | 系统间解耦，独立开发 | 玩家、背包、技能树等独立文件夹 |

---

## 🧩 核心模块

| 模块 | 说明 | 关键脚本 |
|:---|:---|:---|
| **👤 玩家系统** | 移动、战斗、属性、经验 | `PlayerMovement`、`Player_Combat`、`StatsManager`、`ExpManager` |
| **👾 敌人 AI** | 移动、战斗逻辑 | `Enemy_Movement`、`Enemy_Combat` |
| **🎒 背包系统** | 物品管理、掉落、使用 | `InventoryManager`、`ItemSO`、`Loot`、`UseItem` |
| **🌳 技能树** | 技能解锁、效果应用 | `SkillTreeManager`、`SkillSO`、`SkillManager` |
| **🏺 宝箱系统** | 宝箱交互与掉落 | `ChestScripts` 文件夹 |
| **🔄 场景管理** | 场景切换 | `SceneChange`、`GameManager` |
| **🗺️ 地图脚本** | 瓦片地图相关 | `Tilemap Scripts` 文件夹 |

---

## 🛠️ 技术栈

- **Unity 2022.3 LTS** - 游戏引擎
- **C#** - 脚本语言
- **ScriptableObject** - 数据驱动配置
- **单例模式** - 全局管理器
- **Git** - 版本控制

---

## 📂 核心代码快速入口

### ✨ 自定义渲染系统

| 脚本 | 路径 | 说明 |
|:---|:---|:---|
| **受击闪红Shader** | [SpriteFlashRed.shader](https://github.com/C-H-Z/2D-RPG-Demo/blob/main/Scripts/Shader/SpriteFlashRed.shader) | **自定义着色器**，通过Lerp混合实现受击闪红效果 |
| **闪红控制器** | [SpriteFlashEffect.cs](https://github.com/C-H-Z/2D-RPG-Demo/blob/main/Scripts/Shader/SpriteFlashEffect.cs) | 控制Shader参数，实现受伤闪红动画及自动消退 |

### 👤 玩家系统 (`Scripts/PlayerScripts/`)

| 脚本 | 路径 | 说明 |
|:---|:---|:---|
| **玩家移动** | [PlayerMovement.cs](https://github.com/C-H-Z/2D-RPG-Demo/blob/main/Scripts/PlayerScripts/PlayerMovement.cs) | 输入处理与移动逻辑 |
| **玩家战斗** | [Player_Combat.cs](https://github.com/C-H-Z/2D-RPG-Demo/blob/main/Scripts/PlayerScripts/Player_Combat.cs) | 近战攻击、伤害计算 |
| **远程攻击** | [Player_Bow.cs](https://github.com/C-H-Z/2D-RPG-Demo/blob/main/Scripts/PlayerScripts/Player_Bow.cs) | 弓箭射击逻辑 |
| **属性管理器** | [StatsManager.cs](https://github.com/C-H-Z/2D-RPG-Demo/blob/main/Scripts/PlayerScripts/StatsManager.cs) | **单例模式**，管理生命、伤害等属性 |
| **经验系统** | [ExpManager.cs](https://github.com/C-H-Z/2D-RPG-Demo/blob/main/Scripts/PlayerScripts/ExpManager.cs) | 经验获取与升级 |
| **玩家生命** | [PlayerHealth.cs](https://github.com/C-H-Z/2D-RPG-Demo/blob/main/Scripts/PlayerScripts/PlayerHealth.cs) | 受伤、死亡处理 |
| **装备更换** | [Player_ChangeEquipment.cs](https://github.com/C-H-Z/2D-RPG-Demo/blob/main/Scripts/PlayerScripts/Player_ChangeEquipment.cs) | 装备切换逻辑 |
| **属性UI** | [StatsUI.cs](https://github.com/C-H-Z/2D-RPG-Demo/blob/main/Scripts/PlayerScripts/StatsUI.cs) | 属性面板显示 |
| **弓箭逻辑** | [Arrow.cs](https://github.com/C-H-Z/2D-RPG-Demo/blob/main/Scripts/PlayerScripts/Arrow.cs) | 投射物行为 |

### 🎒 背包与商店 (`Scripts/Inventory & Shop/`)

| 脚本 | 路径 | 说明 |
|:---|:---|:---|
| **背包管理器** | [InventoryManager.cs](https://github.com/C-H-Z/2D-RPG-Demo/blob/main/Scripts/Inventory%20&%20Shop/InventoryManager.cs) | **单例模式**，物品管理 |
| **物品数据** | [ItemSO.cs](https://github.com/C-H-Z/2D-RPG-Demo/blob/main/Scripts/Inventory%20&%20Shop/ItemSO.cs) | **ScriptableObject**，物品配置 |
| **背包格子** | [InventorySlot.cs](https://github.com/C-H-Z/2D-RPG-Demo/blob/main/Scripts/Inventory%20&%20Shop/InventorySlot.cs) | UI格子逻辑 |
| **掉落系统** | [Loot.cs](https://github.com/C-H-Z/2D-RPG-Demo/blob/main/Scripts/Inventory%20&%20Shop/Loot.cs) | 敌人死亡掉落 |
| **物品使用** | [UseItem.cs](https://github.com/C-H-Z/2D-RPG-Demo/blob/main/Scripts/Inventory%20&%20Shop/UseItem.cs) | 使用物品效果 |

### 🌳 技能树 (`Scripts/SkillTree/`)

| 脚本 | 路径 | 说明 |
|:---|:---|:---|
| **技能树管理器** | [SkillTreeManager.cs](https://github.com/C-H-Z/2D-RPG-Demo/blob/main/Scripts/SkillTree/SkillTreeManager.cs) | **单例模式**，技能解锁 |
| **技能管理器** | [SkillManager.cs](https://github.com/C-H-Z/2D-RPG-Demo/blob/main/Scripts/SkillTree/SkillManager.cs) | 技能效果应用 |
| **技能数据** | [SkillSO.cs](https://github.com/C-H-Z/2D-RPG-Demo/blob/main/Scripts/SkillTree/SkillSO.cs) | **ScriptableObject**，技能配置 |
| **技能格子** | [SkillSlot.cs](https://github.com/C-H-Z/2D-RPG-Demo/blob/main/Scripts/SkillTree/SkillSlot.cs) | UI格子逻辑 |
| **技能开关** | [ToggleSkillTree.cs](https://github.com/C-H-Z/2D-RPG-Demo/blob/main/Scripts/SkillTree/ToggleSkillTree.cs) | 打开/关闭技能树 |

### 🎮 游戏管理 (`Scripts/SceneChange/`)

| 脚本 | 路径 | 说明 |
|:---|:---|:---|
| **游戏管理器** | [GameManager.cs](https://github.com/C-H-Z/2D-RPG-Demo/blob/main/Scripts/SceneChange/GameManager.cs) | **单例模式**，管理游戏状态、场景切换 |

---

## 🚀 快速开始

```bash
# 克隆仓库
git clone https://github.com/C-H-Z/2D-RPG-Demo.git

# 用 Unity 2022.3 LTS 或更高版本打开项目
