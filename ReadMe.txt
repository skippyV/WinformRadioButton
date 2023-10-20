This project was a playground for creating a custom Winform control.
I originally wanted a two-state slider control. But then settled on
a pair of radio buttons grouped together with a Button appearance.
And raised/inset 3D effect with background color change.
Then wanted to optionally add a dialog allowing the user to cancel
the click action between the two states.

Originally got the code completed in a single Net 6.0 project. But
then decided to move the control into a class library. However,
that was only accomplished by making the class library a .Net Framework (4.8)
class library. Guess you cannot create .Net 6.0 library with winform
stuff. Not sure why.

Another thing I don't understand is how Visual Studio picked up that the
code is GIT managed - considering this scenario:
   1) I placed the VS Solution project in one directory, then next to it
      I put the Project for the class library in another directory.
   2) Then from the common parent directory are initialized Git. So neither
      of the child directories (solution and project) have a .git folder.
	  Only the parent directory.
But when either the project or solution is opened up, VS sees that the files
are now GIT tracked. Now the solution file does have a relative path between
the two projects because I referenced one from the other. So that relative
path "references" the parent directory (the "..") and maybe because of that
VS looks in the parent directory for GIT files? To test that theory I'd have
to do the same thing without referencing one project from the other. TODO.