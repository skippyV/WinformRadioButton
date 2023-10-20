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