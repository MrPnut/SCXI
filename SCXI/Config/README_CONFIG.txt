There are two config files, app.json and logging.json.

logging.json simply allows you to change log levels for categories.  Not really useful unless for debugging.

app.json will be the home of mapping changes and user configurable values.

Currently, the following settings are available for app.json

1. Input/DPadMode

   Default value: "Touch"
   Possible values: "Touch" or "Click"
   Effect: "Touch" mode will register as a DPad button press if the control is TOUCHED
           "Click" mode will register as a DPad button press if the control is CLICKED

