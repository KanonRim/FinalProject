## Code at root level
all project folders are placed in repo root folder - nothing criminal, it's fixable, but usually repositories contain other things aside from a solution. Example:
* `src/` - folder for main code, can be named differently, but exists
* `docs/` - folder for documentation on the project
* `scripts/` - folder for cmd/ps1/bat, etc scripts that help working with the repository
* `.github/` - GitHub uses this folder for repository configuration files (like Github Actions, pull request templates, etc.)
* and other folders if you need them


## Commits are not friendly
* **commits are massive** \
  They have a massive ammount of changes, and it makes it hard to rollback something if something goes wrong. Think of commits as of checkpoints in a game: it would be lame if you needed to start a long mission from the beginning, when you had a last hit to a boss. It would also be lame if it saved after every step - it would be impossible to find the right one. _Find the golden middle - not too much, but a standalone piece of changes._
* **commit messages are the opposite of informative (especially "mimi" one)** \
  Commit messages have a purpose of helping you to find the right commit to reverse (or cherry-pick) and others to see what happened to the repository, when suddenly the app starts acting differently. When all commits named "backup", "fix" and "mimi", it's like sending a middle finger to the future - to your coworkers or future you.


## Wasn't able to launch it

This line in Web.config was throwing error - apparently mode is case sensitive 

```xml
<customErrors mode="off"   defaultRedirect="~/Pages/ErrorPage.cshtml">
```

## Other things
* `ClassLibrary1` folder with DAL.Interface (naming conventions, like Project.(Feature/Layer).Clarification, from common to difference) isn't renamed.
* One DAO and BLL for everything - you combined different responsibilities in one class, it's okay if it's its purpose, but here you should handle persons and orders in different classes. God classes tend to grow bigger and bigger until they become a one big disaster: thousands lines of code, tightly coupled code, everything depends on everything, a dependency spaghetti that is hard to maintain and harder to divide into portions - bugs possibility increases and tests are harder to write too.
* entities are not used as parameters to DAO or BLL
* Logger is used only to catch and retrow exceptions. What about user actions? What about app actions that will help you investigate bugs without running it with debugger?

## What's cool
* Made initialization page, that's cool, no joke
* **Good UI. A bit rough, but still neat and totally usable.**
* entities inherit and aggregate each other
* Role management
* Pages code is somewhat solid

----

Overall, not that bad. There are some places to change, but it's good that you only need to change them and not rewrite from the ground up. Having this app you can re-read SOLID principles, assess your code yourself and fix it.