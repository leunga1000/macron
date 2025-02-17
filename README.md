# control airport:

## situation: 

mac turn off wifi and keep turned off:

wifi keeps turning back on at start up, but no need because have a usb ethernet connection.

turns off airport/wifi adapter for mac and also schedules an alarm (crontab) task to turn it off at restart too.

## to do this manually: 
Open Terminal
crontab -e
you are in vi, a text editor
type i to enter insert mode. copy the following command into the file
@reboot networksetup -setairportpower airport off
type escape to exit insert mode
type :wq  to save the file and quit
done


## to do this with the program 
download the binary in arm64/amd64 and run it

you will be asked for your password for authorisation
