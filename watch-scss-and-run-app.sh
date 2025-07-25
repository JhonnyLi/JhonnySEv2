#!/bin/bash

# Show friendly startup messages
echo "🔁 Starting Sass in watch mode..."
echo "▶️ Starting ASP.NET Core app..."

# Run Sass in the background
# sass --watch JhonnySEv2/Styles/Bundle.scss:wwwroot/css/Bundle.css &
sass --watch --style=compressed JhonnySEv2/Styles/Bundle.scss:wwwroot/css/Bundle.min.css &

# Save the Sass process ID in case you want to kill it later
SASS_PID=$!

# Run dotnet app (in foreground)
cd JhonnySEv2
dotnet run
cd ..

# Optional: when dotnet app exits, stop Sass too
kill $SASS_PID