pipeline {
		options {timestamps()}
		
		agent none
		stages {
			stage('Check scm'){
				agent any
				steps{
					checkout scm
				}
			}
			stage('Build'){
				steps{
					echo "Building ${BUILD_NUMBER}"
					echo "Build completed"
				}
			}
			stage('Test'){
				agent any
				steps{
					sh "dotnet ElementarySchool.Web.dll"
				}
				post{
					success{
						echo "Application compleated"
					}
					failure{
						echo "Error"
					}
				}
			}
		}

	}