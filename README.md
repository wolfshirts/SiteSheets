# SiteSheets 0.1a

## What it's about:
SiteSheets is just an easy way to manage timesheets. The current workflow at the company this is being built for is all on paper.
This means printing out job sheets, and hand writing the hours. If you don't have space on the sheets for tasks completed, adding
a new sheet and making a note of it. The hours are tallied by hand. The sheets often get lost. SiteSheets aims to eventually replace the
entire system. There didn't seem to be a reasonable drop in replacement available, so I'm writing this.

This is a C# app, targeted to work on the companies Windows tablets.

## Currently Supported:
* Add new customers
* Add new contractors
* Add new employees
* Select customer
* Select contractor
* Select employee
* Select employee hours
* List work completed on that day

## To Be Added:
* DB support.
* Materials used in separate field with pricing
* Export hour sheets to PDF
* OneDrive integration
* More as feature creep happens.....

## Why not Java?
Java would seem to be the goto language for this type of application. But I'm not using it for a couple reasons, I'm coming from Python and a little
bit of C/C++, C# is where I landed for my next language. Mono is pretty good. It's not the best, but I have already written one
cross platform GUI app in it (https://github.com/wolfshirts/youtube-getter), I figure if this needs to be more cross platform at
any point, by that time Xamarin GUI's will be even better. Obviously not as good as a native implementation, but good enough.
