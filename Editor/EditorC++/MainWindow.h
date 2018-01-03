#pragma once
#include <Core\Engine_Interface.h>
#include <Core\EngineException.h>
namespace EditorC {

	using namespace System;
	using namespace System::ComponentModel;
	using namespace System::Collections;
	using namespace System::Windows::Forms;
	using namespace System::Data;
	using namespace System::Drawing;

	/// <summary>
	/// Summary for MainWindow
	/// </summary>
	public ref class MainWindow : public System::Windows::Forms::Form
	{
	public:
		MainWindow(void)
		{
			engine = nullptr;
			InitializeComponent();
			//
			//TODO: Add the constructor code here
			//
			try
			{
				EngineInitializationInfo ii;
				ii.subSystems.fileSystem = CreateFileSystem(ResourceHandler::FileSystemType::Binary);
				if (!ii.subSystems.fileSystem)
					THROWERROR("Could not create file system", -1);
				auto r = ii.subSystems.fileSystem->Init("data.dat", ResourceHandler::Mode::EDIT);
				if (r < 0)
					THROWERROR("Could not init file system", r);
				
				engine = CreateEngine(ii);
			}
			catch (const Core::Engine_Exception& e)
			{
				MessageBox::Show(gcnew String(( e.msg+ "\nFile: " + e.file + "\nLine: " + std::to_string(e.line)).c_str()), "Error: " + e.error.ToString(),MessageBoxButtons::OK, MessageBoxIcon::Error);
			}
		}

	protected:
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		~MainWindow()
		{
			if (components)
			{
				delete components;
			}
			if (engine)
			{
				try
				{
					engine->Shutdown();
				}
				catch (const Core::Engine_Exception& e)
				{
					MessageBox::Show(gcnew String((e.msg + "\nFile: " + e.file + "\nLine: " + std::to_string(e.line)).c_str()), "Error: " + e.error.ToString(), MessageBoxButtons::OK, MessageBoxIcon::Error);
				}
				delete engine;
				engine = nullptr;
			}
		}

	private:
		Core::Engine_Interface* engine;


		/// <summary>
		/// Required designer variable.
		/// </summary>
		System::ComponentModel::Container ^components;

#pragma region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		void InitializeComponent(void)
		{
			this->SuspendLayout();
			// 
			// MainWindow
			// 
			this->AutoScaleDimensions = System::Drawing::SizeF(6, 13);
			this->AutoScaleMode = System::Windows::Forms::AutoScaleMode::Font;
			this->ClientSize = System::Drawing::Size(284, 261);
			this->IsMdiContainer = true;
			this->Name = L"MainWindow";
			this->Text = L"MainWindow";
			this->ResumeLayout(false);

		}
#pragma endregion
	};
}
