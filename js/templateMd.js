const path = require('path');
const fsp = require('fs/promises');

const template = `
## 

**Beschreibung:**


**Deklaration:**

\`\`\`C#

\`\`\`

---

*Test Program:*

\`\`\`C#



\`\`\`

*Ausgabe sollte sein:*



---
`;
const initTemplatePart =`
# 

**Einführung:**


`;
const startTemplate = initTemplatePart + template;

const firstArg = process.argv[2];
const secondArg = process.argv[3];

(async() => {
        
    if (firstArg) {
        if (firstArg !== "appendTo") {
            createMdFile();
        } else {            
            appendToMdFile();
        }
    } else {
        endWithError("No name to was provided for the md file !");
    }
})();

function endWithError(message) {
    console.error(message);
    process.exit(-1);
}

async function createMdFile() {
    const outputPath = path.resolve('./', firstArg + '.md');
    try {
        console.log(`Creating md file ${outputPath}`);
        await fsp.writeFile(outputPath, startTemplate);
    } catch (error) {
        endWithError(error);
    }
}

async function appendToMdFile() {
    if (secondArg) {                
        try {

            const outputPath = path.resolve('./', secondArg);
            console.log(`outputPath: ${outputPath}`);
            const fileStatus = await fsp.stat(outputPath);
            if (fileStatus.isDirectory() === true) {
                endWithError("Target is a directory and not md file");
            } else if (path.extname(outputPath) !== '.md') {
                endWithError("Target file is not a md file !");
            } else {
                await fsp.appendFile(outputPath, template);
            }

        } catch(error) {
            endWithError(error);
        }
    } else {
        endWithError("No name for the md file which the template is to be appended to");
    }
}