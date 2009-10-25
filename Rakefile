# -*- Mode: ruby -*-
#
# Rakefile to construct the RMSC Booklet maker solution
#
require 'rake/clean'
require 'utils'

# Control whether the C# code is compiled in Debug mode
DEBUG_FLAG = false

BIN_DIR = "bin"

PACKAGE_DIR = "package"

APPLICATION = "RMSCBookletMaker"

# The list of projects to build
PROJECTS = [ APPLICATION ]

TARGETS = [ "compile",
            "deploy",
            "clean",
            "clobber",
            "test"
          ]

CLOBBER.include(BIN_DIR, PACKAGE_DIR)

# Set up the default target
task :default => [ :compile ]

# Prepare the environment for compiling
task :compile_init do
  mkdir_p BIN_DIR if not File.exists?(BIN_DIR)
end

# Prepare the environment for packaging
task :package_init do
  mkdir_p PACKAGE_DIR if not File.exists?(PACKAGE_DIR)
end

task "RMSCBookletMaker.compile" => [ :compile_init ]

task :compile => [ "#{APPLICATION}.compile" ]

task :deploy => PROJECTS.collect { |p| "#{p}.deploy" }

task :test => PROJECTS.collect { |p| "#{p}.test" }

task :clean => PROJECTS.collect { |p| "#{p}.clean" }

task :clobber => PROJECTS.collect { |p| "#{p}.clobber" }

# Package the final result
task :package => [ :package_init, :deploy ] do
  print "#######################################################\n"
  pkdir = "#{PACKAGE_DIR}/#{APPLICATION}"
  # Create the package directory
  mkdir_p pkdir if not File.exists?(pkdir)
  tarball = "#{PACKAGE_DIR}/#{APPLICATION}.tar.gz"
  # Remove the tarball if it already exists
  rm tarball if File.exists?(tarball)
  # Copy the lib files to underneath the package directory. This 
  # provides the directory structure we want for the tar ball.
  sh "cp -r #{BIN_DIR}/* #{pkdir}"
  # Tar up the distribution into the appropriate structure.
  tar_cmd = "tar czf #{tarball}"
  tar_cmd << " --directory #{PACKAGE_DIR}"
  tar_cmd << " #{APPLICATION}"
  sh tar_cmd
end

# Define all the project-level rake tasks
PROJECTS.each do |prj|
  TARGETS.each do |tgt|
    createTask prj, tgt
  end
end
