#
# Invokes rake in the specified directory with the specified
# target
#
def invokeRake(directory, target)
  cmd = "(cd #{directory}; rake #{target} BIN_DIR=../#{BIN_DIR} DEBUG_FLAG=#{DEBUG_FLAG})"
  sh cmd
end

#
# Constructs a new task for the project/target combination.
# The target will invoke a rake target on the subproject
#
def createTask(project, target)
  task "#{project}.#{target}" do
    print "#######################################################\n"
    invokeRake project, target
  end
end

