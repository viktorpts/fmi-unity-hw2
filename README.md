# Unity Homework 5: Healthbar

Author: Viktor Kostadinov, FN: 26312

## Implementation details

### Usage
The existing **Fight Scene** is used to implement the homework. The following files have been added to the project:
* `Assets/Prefabs/HBar.prefab`
* `Assets/Scripts/Healthbar.cs`

The following files (apart from the scene) have been modified:
* `Assets/Scripts/Health.cs`

### Healthbar Prefab and Script
A prefab `HBar` has been created, with a script that keeps track of a single GameObject. In order for the healthbar to work, the tracked object must have a `Health` component. The script makes use of events that pass in the changes to the health, which is applied to the graphic representation gradually with a simple animation.

You may add as many HBars in the scene as you need, position them anywhere and just drag-and-drop a character to the associated `target` slot, to make the healtbar work. You may also apply **negative horizontal scale** to the container, which makes the health deplete left-to-right, instead of right-to-left, as seen on the HBar_Enemy object.

### Changes to existing code
A couple of changes have been made to the existing `Health` script:
* The starting health is moved to a constant, to avoid magic numbers in the code
* A delegate and associated event have been added, to facilitate health tracking
* The `TakeDamage` method has been modified to invoke any event listeners

A much simpler modification could have been made, making the `health` member public. This, however, could result in any external script modifying the health of the character without an easy way to track and debug such changes.

## Extension Ideas
* The width of the healthbar is hardcoded to be 200 units, but this can easily be made dynamic with a variable that stores the starting width of the container
* To make the healthbar account for increasing health (e.g. picking up a medkit), the following modification to the `Update` method of `Healthbar.cs` can be made:
```csharp
void Update()
{
    if (currentHp != targetHp)
    {
        if (currentHp > targetHp)
        {
            currentHp -= 0.25f;
        }
        else
        {
            currentHp += 0.25f;
        }
        float width = (currentHp / max) * 200f;
        wipe.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, width);
    }
}
```
* It'd be cool to make the hp depletion animation include a different-colored section to mark the amount of damage taken, which then gradually wipes off, like the one seen here:

![healthbar](https://i.imgur.com/p1ErowC.gif).
