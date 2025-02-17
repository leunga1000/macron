# Macron

Utility to edit your cron file automatically.

## Example situation

On mac wifi keeps turning back on at start up, but no need because have a usb ethernet connection.

Turns off airport/wifi adapter for mac and also schedules an alarm (crontab) task to turn it off at restart too.

## To do this manually

Open Terminal

crontab -e

you are in vi, a text editor

type i to enter insert mode. copy the following command into the file

@reboot networksetup -setairportpower airport off

type escape to exit insert mode

type :wq  to save the file and quit

done


## To do this with the program 
Download the binary in arm64/amd64 and run it

You will be asked for your password for authorisation
