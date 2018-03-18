#!/usr/bin/env bash
bundle check || bundle install
clear
bundle exec rspec