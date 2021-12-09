pipeline {
		options {timestamps()}
		
		agent any
		stages {
			stage('Check scm'){
				agent any
				steps{
					checkout scm
				}
			}
			stage('Build'){
				agent{docker {image 'dotnet-5.0'
						}
					}
				steps{
					echo "Building ${BUILD_NUMBER}"
					sh "dotnet build"
					echo "Build completed"
				}
			}
			stage('Test'){
				agent{docker {image 'dotnet-5.0'
						}
					}
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
