import os
import xml.etree.ElementTree as ET
from xml.dom import minidom

def dir_to_xaml(path, parent_element):
    """
    Recursively traverses the directory structure starting from 'path',
    adding elements to the 'parent_element' to represent directories and files in XAML.
    """
    if os.path.isdir(path):
        for item in os.listdir(path):
            item_path = os.path.join(path, item)
            if os.path.isdir(item_path):
                # Create a new element for the directory
                dir_element = ET.SubElement(parent_element, 'Directory', name=item)
                dir_to_xaml(item_path, dir_element)  # Recurse into the directory
            else:
                # Create an element for the file
                ET.SubElement(parent_element, 'File', name=item)

def create_xaml_tree(root_path):
    """
    Creates a XAML tree structure for the directory and files starting from 'root_path'.
    """
    root_element = ET.Element('Root', path=root_path)
    dir_to_xaml(root_path, root_element)
    rough_string = ET.tostring(root_element, 'utf-8')
    reparsed = minidom.parseString(rough_string)
    return reparsed.toprettyxml(indent="  ")


root_path = 'PATH'  # Replace with your directory path
xaml_output = create_xaml_tree(root_path)
print(xaml_output)

# Optionally, save the XAML to a file
with open('directory_structure.xaml', 'w') as file:
    file.write(xaml_output)
