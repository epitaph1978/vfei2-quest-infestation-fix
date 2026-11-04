# [Epis] VFE Insectoids 2 - Quest Infestation Fix

**Authors:** Epitaph & Gemini 3.8 Flash  
**Compatibility:** RimWorld 1.5, 1.6, 1.7  
**Distribution:** Designed for Libidinous Loader and manual installation.

---

## 📖 Description

Fixes a bug where Vanilla Infestation Quests (such as 'Pods and Hives' / ThreatReward_Infestation_ItemPod) spawn empty hives without any adult insects when Vanilla Factions Expanded - Insectoids 2 (VFEI2) is installed.

Technical details:
Vanilla QuestPart_Infestation passes null insectPoints to InfestationUtility.SpawnTunnels (relying on vanilla Hive CompSpawnerPawn). VFEI2 replaces CompSpawnerPawn with CompInsectSpawner (which only spawns on infested world tiles) and delegates insect spawning to TunnelHiveSpawner. Because quest tunnels received null points, zero insects were spawned.

This mod intercepts tunnel spawns with missing insectPoints and dynamically injects the appropriate combat points so VFEI2 immediately spawns the insect defenders and assault swarms.

---

## 📦 Installation

1. Download or clone this repository.
2. Place the folder into your `RimWorld/Mods/` directory.
3. Activate the mod in RimWorld's Mod Manager (or auto-install with Libidinous Loader).
