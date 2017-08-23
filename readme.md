# opsout
Quit chasing folks to see if something needs a deployment. -OR- My goal to keep ops out of my day.

## Purpose
This application is meant to simplify looking at multiple Bamboo deployments and visually comparing versions across environments.
With opsout, you provide a plan key and the environments to compare, and you'll get a simple green or red output indicating if any upper environments *require deployment.

*require deployment means, the deployed version differs from the lowest environment.

## Use
First, copy, paste, and rename App.config.template to App.config and add your Bamboo server url, user and password to the .config.

opsout.exe {planId}|{environment1},{environment2}[,{environmentN}]

For provided a planId(s), will output a green (versions are the same) entry or red (versions differ) between environment1 and subsequent environments.

Multiple plans and environments can also be provided separating entries by spaces.

## Examples
### Single example
optsout.exe 86179841|Internal,Release,Production

### Multiple example
optsout.exe 86179841|Internal,Release,Production 86179850|Internal,Production,Release 115048450|DEV,UAT,PROD

## Dedication
This is a gift, to all the Managers and Operations folks who have had to chase down folks from teams to determine if a application/component needs to be deployed.
