using System.IO;
using UnityEditor;
using UnityEditor.Callbacks;
using UnityEditor.iOS.Xcode;
using UnityEngine;

public class PlistEditor
{
	[PostProcessBuild(1)]
	public static void ChangeXcodePlist(BuildTarget buildTarget, string pathToBuiltProject)
	{
		if (buildTarget == BuildTarget.iOS)
		{
			// Get plist file and read it.
			var plistPath = pathToBuiltProject + "/Info.plist";
			Debug.Log("In the ChangeXCodePlist, path is: " + plistPath);
			var plist = new PlistDocument();
			plist.ReadFromString(File.ReadAllText(plistPath));
			Debug.Log("In the ChangeXCodePlist");

			// Get root
			var rootDict = plist.root;

			// Required when using camera for demos, e.g. AR demos.
			rootDict.SetString("NSCameraUsageDescription", "Uses the camera for Augmented Reality");

			// Required when using photo library in demo (i.e. reading library).
			rootDict.SetString("NSPhotoLibraryUsageDescription", "${PRODUCT_NAME} photo use");

			// Required when adding images to photo library in demos.
			rootDict.SetString("NSPhotoLibraryAddUsageDescription", "${PRODUCT_NAME} photo use");

			//ITSAppUsesNonExemptEncryption, this value is required for release in TestFlight.
			rootDict.SetBoolean("ITSAppUsesNonExemptEncryption", false);

			Debug.Log("PLIST: " + plist.WriteToString());

			// Write to file
			File.WriteAllText(plistPath, plist.WriteToString());
			File.WriteAllText(pathToBuiltProject + "/info2.plist", plist.WriteToString());
		}
	}
}
