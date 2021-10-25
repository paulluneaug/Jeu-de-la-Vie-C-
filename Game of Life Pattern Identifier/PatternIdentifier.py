from PIL import Image, ImageDraw

def GameLifePatternFinder(imgName,extension):
    
    img=Image.open(imgName+extension)
    img=img.convert('L')
    img.ImageDraw.rectangle(0,0,1,1)
    img.save("spagmod.png")
    
    
    
    cellSize, xFirstCell, yFirstCell = GetCellSize(img)
    print(f"Cell size : {cellSize}")# Setting the points for cropped image
    left = xFirstCell
    top = yFirstCell
    right = img.size[0]
    bottom = img.size[1]
 
    # Cropped image of above dimension
    # (It will not change original image)
    img = img.crop((left, top, right, bottom))
    #img.show()
    resX, resY = img.size
    lines = []
    for j in range(resY//cellSize):
        line = ""
        for i in range(resX//cellSize):
            if (img.getpixel((int(i * cellSize + cellSize/2), int(j * cellSize + cellSize/2))) == 0):
                line += "0"
            else:
                line += " "
        lines.append(line)
    print("Lines done")
    
    #Deletes the empty lines at the top of the pattern
    emptyLine = " " * (resX//cellSize)
    iLine = 0
    firstCellDeleted = False
    while iLine < len(lines):
        isEmptyLine = lines[iLine] == emptyLine
        if (isEmptyLine or not firstCellDeleted):
            lines.pop(0)
            if (not isEmptyLine):
                firstCellDeleted = True
        else :
            break
        
    print("Upper empty lines deleted")
    
    
    
    #Deletes the empty lines at the bottom of the pattern
    iLine = len(lines)-1
    while iLine > 0:
        isEmptyLine = lines[iLine] == emptyLine
        if (isEmptyLine):
            lines.pop(len(lines)-1)
            iLine-=1
        else :
            break
        
    print("Lower empty lines deleted")
    
    for a in range(2):
        
        colmunsToDelete = len(lines[0])
        for line in lines:
            first0 = line.find("0")
            if first0 != -1:
                colmunsToDelete = min( colmunsToDelete,first0)
        print(colmunsToDelete)
        
        for iLine in range(len(lines)):
            lines[iLine] = Reverse(lines[iLine][ colmunsToDelete:])
    
    print ("Lateral empty columns deleted")
 
    strImg = ""
    for line in lines :
        strImg += line + "\n"
    
    print(strImg, file = open(f"{imgName}.txt",'w',encoding='utf-8'))
            
            
        
    
        
            
    
def GetCellSize(img):
    """"""
    resX, resY = img.size
    y = 0
    found = False
    while not found and  y<resY:
        x = 0
        while  not found and  x<resX:
            if img.getpixel((x,y))==0:
                print(f"First black cell : {x}, {y}")
                found = True
            x+=1
        y+=1
    cellSize = 1
    while (img.getpixel((x + cellSize, y)) == 0):
        cellSize+=1
    return cellSize,x,y

def Reverse(string):
    revStr = ""
    for a in string:
        revStr = a + revStr
    return revStr
    
    
    
GameLifePatternFinder("Spaghetti Monster", ".png")